using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tp3_A21
{
    public partial class FrmBalise : Form
    {
        private Balise _balise;
        private readonly Dictionary<string, string> _attributs;

        public Balise Balise
        {
            get { return _balise; }
        }

        public FrmBalise()
        {
            InitializeComponent();
            _attributs = new Dictionary<string, string>();
        }

        private void btnAjoutAttribut_Click(object pSender, EventArgs pE)
        {
            FrmAttribut formSecondaire = new FrmAttribut();
            if (formSecondaire.ShowDialog() == DialogResult.OK)
            {
                _attributs.Add(formSecondaire.Cle, formSecondaire.Valeur);
                AffichageAttributs();
            }
        }

        private void btnSuppAttribut_Click(object pSender, EventArgs pE)
        {
            if (lbAttributs.SelectedIndex != -1)
            {
                _attributs.Remove(((KeyValuePair<string, string>) lbAttributs.SelectedItem).Key);
                AffichageAttributs();
            }
                
        }

        private void btnAjoutBalise_Click(object pSender, EventArgs pE)
        {
            if (ValidationNom())
            {
                _balise = new Balise(txtNom.Text,_attributs,txtContenu.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void AffichageAttributs()
        {
            lbAttributs.Items.Clear();
            foreach (KeyValuePair<string, string> attribut in _attributs)
            {
                lbAttributs.Items.Add(attribut);
            }
        }

        private bool ValidationNom()
        {
            if (String.IsNullOrEmpty(txtNom.Text))
            {
                errorProvider1.SetError(txtNom, "Le nom ne peut pas être vide");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtNom, "");
                return true;
            }
        }
    }
}