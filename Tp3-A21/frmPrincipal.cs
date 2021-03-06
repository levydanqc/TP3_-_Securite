using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tp3_A21.Properties;

namespace Tp3_A21
{
    public partial class FrmPrincipal : Form
    {
        private string _fileName = "";

        public FrmPrincipal()
        {
            InitializeComponent();
            btnMonter.Image = new Bitmap(Resources.arrowup, btnMonter.Width, btnMonter.Height);
            btnDescendre.Image = new Bitmap(Resources.arrowdown, btnDescendre.Width, btnDescendre.Height);
        }

        #region A faire

        private void ouvrirToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"Fichiers html (*.html)|*.html";
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
                    HtmlToNode(tags, firstNode);
                    tvHTML.Nodes.Add(firstNode);
                }

            }
        }

        /// <summary>
        /// Fonction récursice de conversion d'une liste
        /// de string de tag html en un arbre
        /// </summary>
        /// <param name="pTags">Une liste de string de tag html</param>
        /// <param name="pNoeudCourant">Le noeud parent actuel de l'arbre</param>
        private void HtmlToNode(List<String> pTags, TreeNode pNoeudCourant)
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
                HtmlToNode(pTags, pNoeudCourant);
        }
        
        /// <summary>
        /// Fonction de conversion d'un chaine de caractères
        /// en une instance de la classe Balise
        /// </summary>
        /// <param name="pTag">Une string d'un tag HTML</param>
        /// <returns>Une instance de la classe Balise correspondant au tag</returns>
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

        private void enregistrerToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            if (_fileName != "")
            {
                WriteToFile(_fileName);
            }
            else
            {
                enregistrerSousToolStripMenuItem_Click(pSender, pE);
            }
        }

        private void enregistrerSousToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = @"Fichiers html (*.html)|*.html";
            sfd.DefaultExt = "html";
            sfd.Title = @"Enregistrer le fichier HTML";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WriteToFile(sfd.FileName);
            }

            _fileName = sfd.FileName;
        }

        /// <summary>
        /// Fonction d'écriture du TreeView en un fichier HTML
        /// </summary>
        /// <param name="pFileName">Le nom du fichier dans lequel enregistrer</param>
        private void WriteToFile(string pFileName)
        {
            List<string> tags = new List<string>() { "<!-- AUTO-GENERATED HTML -->", "<!DOCTYPE html>" };

            foreach (Balise balise in tvHTML.Nodes)
            {
                tags.AddRange(balise.ToHtml());
            }

            using StreamWriter sw = new StreamWriter(pFileName, false);
            sw.WriteLine(string.Join("\n", tags));
        }

        private void btnRechParId_Click(object pSender, EventArgs pE)
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


        private void btnRechParTags_Click(object pSender, EventArgs pE)
        {
            foreach (Balise balise in tvHTML.Nodes)
            {
                lbRechParTag.DataSource = balise.HasTag(txtRechTags.Text).ToArray();
            }
        }

        private void btnMonter_Click(object pSender, EventArgs pE)
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

        private void btnDescendre_Click(object pSender, EventArgs pE)
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

        private void nouveauToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            tvHTML.Nodes.Clear();
            tvHTML.Nodes.Add(new Balise("html"));
            tvHTML.Nodes[0].Nodes.Add(new Balise("head"));
            tvHTML.Nodes[0].Nodes.Add(new Balise("body"));
        }

        private void ajouterToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            if (ValidationHtml())
            {
                FrmAttribut formSecondaire = new FrmAttribut();
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
                        MessageBox.Show(@"Attribut déjà présent dans cet élément");
                    }
                }
            }
        }

        private void fermerToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            Close();
        }

        private void ajouterUnElementToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            RetirerErreurs();
            FrmBalise formSecondaire = new FrmBalise();
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

        private void supprimerToolStripMenuItem_Click(object pSender, EventArgs pE)
        {
            if (ValidationHtml())
            {
                tvHTML.SelectedNode.Remove();
            }
        }

        private void supprimerToolStripMenuItem1_Click(object pSender, EventArgs pE)
        {
            if (ValidationAttribut())
            {
                ((Balise)tvHTML.SelectedNode).Attributs.Remove(
                    ((KeyValuePair<string, string>)lbAttributs.SelectedItem).Key);
                AffichageAttributs();
                tvHTML.SelectedNode.Text = tvHTML.SelectedNode.ToString();
            }
        }

        #endregion

        #region EvenementUI

        private void btnSauvContenu_Click(object pSender, EventArgs pE)
        {
            if (ValidationHtml())
            {
                ((Balise)tvHTML.SelectedNode).Contenu = txtContenu.Text;
                tvHTML.Focus();
            }
        }

        private void tvHTML_AfterSelect(object pSender, TreeViewEventArgs pE)
        {
            if (ValidationHtml())
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

        private void lbRechParTag_SelectedIndexChanged(object pSender, EventArgs pE)
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

        private bool ValidationHtml()
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