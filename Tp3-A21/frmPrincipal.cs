using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Tp3_A21.Properties;

namespace Tp3_A21
{
    public partial class frmPrincipal : Form
    {
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
                //TODO#1 Chargement du fichier HTML
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO#2 Enregistrement du fichier
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fichiers html (*.html)|*.html";
            sfd.DefaultExt = "html";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //TODO#2 Enregistrement du fichier
            }
        }

        private void btnRechParId_Click(object sender, EventArgs e)
        {
            //TODO#3 RechercheParId
        }


        private void btnRechParTags_Click(object sender, EventArgs e)
        {
            //TODO#4 RechercheParTag
        }

        private void btnMonter_Click(object sender, EventArgs e)
        {
            //TODO#5 Faire monter la balise sélectionnée
        }

        private void btnDescendre_Click(object sender, EventArgs e)
        {
            //TODO#5 Faire descendre la balise sélectionnée
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
                    if (!((Balise) tvHTML.SelectedNode).Attributs.ContainsKey(formSecondaire.Cle))
                    {
                        ((Balise) tvHTML.SelectedNode).Attributs.Add(formSecondaire.Cle, formSecondaire.Valeur);
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
                ((Balise) tvHTML.SelectedNode).Attributs.Remove(
                    ((KeyValuePair<string, string>) lbAttributs.SelectedItem).Key);
                AffichageAttributs();
            }
        }

        #endregion

        #region EvenementUI

        private void btnSauvContenu_Click(object sender, EventArgs e)
        {
            if (ValidationHTML())
            {
                ((Balise) tvHTML.SelectedNode).Contenu = txtContenu.Text;
                tvHTML.Focus();
            }
        }

        private void tvHTML_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ValidationHTML())
            {
                AffichageAttributs();
                txtContenu.Text = ((Balise) tvHTML.SelectedNode).Contenu;
            }
        }

        private void AffichageAttributs()
        {
            lbAttributs.Items.Clear();
            if (tvHTML.SelectedNode != null)
            {
                foreach (KeyValuePair<string, string> attribut in ((Balise) tvHTML.SelectedNode).Attributs)
                {
                    lbAttributs.Items.Add(attribut);
                }
            }
        }

        private void lbRechParTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRechParTag.SelectedIndex != -1)
            {
                tvHTML.SelectedNode = (Balise) lbRechParTag.SelectedItem;
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