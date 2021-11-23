﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Tp3_A21.Properties;

namespace Tp3_A21
{
    public partial class frmPrincipal : Form
    {
        private string _fileName = "";
        private TreeNode _parentNode;

        public frmPrincipal()
        {
            InitializeComponent();
            btnMonter.Image = new Bitmap(Resources.arrowup, btnMonter.Width, btnMonter.Height);
            btnDescendre.Image = new Bitmap(Resources.arrowdown, btnDescendre.Width, btnDescendre.Height);
        }

        #region A faire

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fichiers html (*.html)|*.html";
            ofd.DefaultExt = "html";
            tvHTML.Nodes.Clear();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader file = new StreamReader(ofd.FileName))
                {
                    string html = file.ReadToEnd();
                    html = html.Replace("\r", "");
                    html = html.Replace("\n", "");
                    List<string> tags = html.Split('<').ToList();

                    foreach (string tag in tags.ToList())
                    {
                        if (tag == "")
                        {
                            tags.Remove(tag);
                        }
                        if (Regex.IsMatch(tag, @"!(.*?)>"))
                        {
                            tags.Remove(tag);
                        }
                    }

                    Balise firstNode = StringToBalise(tags[0]);
                    tags.RemoveAt(0);
                    HtmlToTreeView(tags, firstNode);
                    tvHTML.Nodes.Add(firstNode);
                }

            }
        }

        private void HtmlToTreeView(List<String> pTags, TreeNode pNoeudCourant)
        {
            if (pTags[0][0] == '/')
            {
                pNoeudCourant = pNoeudCourant.Parent;
            }
            else
            {
                Balise balise = StringToBalise(pTags[0]);
                pNoeudCourant.Nodes.Add(balise);
                if (!balise.IsSelfClosing)
                    pNoeudCourant = balise;
            }
            pTags.RemoveAt(0);

            if (pTags.Count > 0)
                HtmlToTreeView(pTags, pNoeudCourant);
        }

        private Balise StringToBalise(String pTag)
        {
            MatchCollection matches = Regex.Matches(pTag, @"(\S+)=[""']?((?:.(?![""']?\s+(?:\S+)=|\s*\/?[>""']))+.)[""']?");
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (Match m in matches)
            {
                dict.Add(m.Groups[1].Value, m.Groups[2].Value);
            }

            Balise balise = new Balise(
            pNom: Regex.Match(pTag, @"(\w+)\s*\w*.*?>").Groups[1].Value,
            pAttributs: dict,
            pContenu: Regex.Match(pTag, @".*?>(\w+.*)").Groups[1].Value
            );

            return balise;

        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileName != "")
            {
                WriteToFile(_fileName);
            }
            else
            {
                enregistrerSousToolStripMenuItem_Click(sender, e);
            }
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fichiers html (*.html)|*.html";
            sfd.DefaultExt = "html";
            sfd.Title = "Enregistrer le fichier HTML";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WriteToFile(sfd.FileName);
            }

            _fileName = sfd.FileName;
        }

        private void WriteToFile(string pFileName)
        {
            List<String> tags = new List<string>() { "<!-- AUTO-GENERATED HTML -->", "<!DOCTYPE html>" };

            foreach (Balise balise in tvHTML.Nodes)
            {
                tags.AddRange(balise.ToHTML());
            }

            using StreamWriter sw = new StreamWriter(pFileName, false);
            sw.WriteLine(string.Join("\n", tags));
        }

        private void btnRechParId_Click(object sender, EventArgs e)
        {
            int i = 0;
            tvHTML.SelectedNode = null;

            while (tvHTML.SelectedNode == null && i < tvHTML.Nodes.Count)
            {
                tvHTML.SelectedNode = ((Balise)tvHTML.Nodes[i]).FindById(txtRechID.Text);
                i++;
            }

            tvHTML.Focus();
        }


        private void btnRechParTags_Click(object sender, EventArgs e)
        {
            foreach (Balise balise in tvHTML.Nodes)
            {
                lbRechParTag.DataSource = balise.HasTag(txtRechTags.Text).ToArray();
            }
        }

        private void btnMonter_Click(object sender, EventArgs e)
        {
            if (tvHTML.SelectedNode != null)
            {
                TreeNode parent = tvHTML.SelectedNode.Parent;
                int i = parent.Nodes.IndexOf(tvHTML.SelectedNode);
                if (i > 0)
                {
                    TreeNode tempo = tvHTML.SelectedNode;
                    parent.Nodes.RemoveAt(i);
                    parent.Nodes.Insert(i - 1, tempo);
                }
            }
            tvHTML.Focus();
        }

        private void btnDescendre_Click(object sender, EventArgs e)
        {
            if (tvHTML.SelectedNode != null)
            {
                TreeNode parent = tvHTML.SelectedNode.Parent;
                int i = parent.Nodes.IndexOf(tvHTML.SelectedNode);
                if (i < parent.Nodes.Count - 1)
                {
                    TreeNode tempo = tvHTML.SelectedNode;
                    parent.Nodes.RemoveAt(i);
                    parent.Nodes.Insert(i + 1, tempo);
                }
            }
            tvHTML.Focus();
        }



        #endregion


        #region Menu

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvHTML.Nodes.Clear();
            tvHTML.Nodes.Add(new Balise("html"));
            tvHTML.Nodes[0].Nodes.Add(new Balise("head"));
            tvHTML.Nodes[0].Nodes.Add(new Balise("body"));
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidationHTML())
            {
                frmAttribut formSecondaire = new frmAttribut();
                if (formSecondaire.ShowDialog() == DialogResult.OK)
                {
                    if (!((Balise)tvHTML.SelectedNode).Attributs.ContainsKey(formSecondaire.Cle))
                    {
                        ((Balise)tvHTML.SelectedNode).Attributs.Add(formSecondaire.Cle, formSecondaire.Valeur);
                        AffichageAttributs();
                        tvHTML.SelectedNode.Text = tvHTML.SelectedNode.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Attribut déjà présent dans cet élément");
                    }
                }
            }
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ajouterUnElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetirerErreurs();
            frmBalise formSecondaire = new frmBalise();
            if (formSecondaire.ShowDialog() == DialogResult.OK)
            {
                if (tvHTML.SelectedNode == null)
                {
                    if (tvHTML.Nodes.Count > 0)
                    {
                        errorProvider1.SetError(tvHTML,
                            "Impossible d'avoir deux noeuds racines dans le fichier. Veuillez sélectionner une balise HTML");
                    }
                    else
                        tvHTML.Nodes.Add(formSecondaire.Balise);
                }
                else
                {
                    tvHTML.SelectedNode.Nodes.Add(formSecondaire.Balise);
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidationHTML())
            {
                tvHTML.SelectedNode.Remove();
            }
        }

        private void supprimerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ValidationAttribut())
            {
                ((Balise)tvHTML.SelectedNode).Attributs.Remove(
                    ((KeyValuePair<string, string>)lbAttributs.SelectedItem).Key);
                AffichageAttributs();
            }
        }

        #endregion

        #region EvenementUI

        private void btnSauvContenu_Click(object sender, EventArgs e)
        {
            if (ValidationHTML())
            {
                ((Balise)tvHTML.SelectedNode).Contenu = txtContenu.Text;
                tvHTML.Focus();
            }
        }

        private void tvHTML_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ValidationHTML())
            {
                AffichageAttributs();
                txtContenu.Text = ((Balise)tvHTML.SelectedNode).Contenu;
            }
        }

        private void AffichageAttributs()
        {
            lbAttributs.Items.Clear();
            if (tvHTML.SelectedNode != null)
            {
                foreach (KeyValuePair<string, string> attribut in ((Balise)tvHTML.SelectedNode).Attributs)
                {
                    lbAttributs.Items.Add(attribut);
                }
            }
        }

        private void lbRechParTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRechParTag.SelectedIndex != -1)
            {
                tvHTML.SelectedNode = (Balise)lbRechParTag.SelectedItem;
                tvHTML.Focus();
            }
        }

        #endregion

        #region ValidationUI

        private void RetirerErreurs()
        {
            errorProvider1.SetError(tvHTML, "");
            errorProvider1.SetError(lbAttributs, "");
        }

        private bool ValidationHTML()
        {
            RetirerErreurs();
            if (tvHTML.SelectedNode == null)
            {
                errorProvider1.SetError(tvHTML, "Veuillez sélectionner une balise HTML");
                return false;
            }

            return true;
        }

        private bool ValidationAttribut()
        {
            RetirerErreurs();
            if (lbAttributs.SelectedIndex == -1)
            {
                errorProvider1.SetError(lbAttributs, "Veuillez sélectionner un attribut");
                return false;
            }

            return true;
        }

        #endregion
    }
}