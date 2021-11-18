using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp3_A21
{
    public partial class frmBalise : Form
    {
        private Balise _balise;
        private Dictionary<string, string> _attributs;

        public Balise Balise
        {
            get { return _balise; }
        }

        public frmBalise()
        {
            InitializeComponent();
            _attributs = new Dictionary<string, string>();
        }

        private void btnAjoutAttribut_Click(object sender, EventArgs e)
        {
            frmAttribut formSecondaire = new frmAttribut();
            if (formSecondaire.DialogResult == DialogResult.OK)
            {
                _attributs.Add(formSecondaire.Cle, formSecondaire.Valeur);
                AffichageAttributs();
            }
        }

        private void btnSuppAttribut_Click(object sender, EventArgs e)
        {
            if (lbAttributs.SelectedIndex != -1)
            {
                _attributs.Remove(((KeyValuePair<string, string>) lbAttributs.SelectedItem).Key);
                AffichageAttributs();
            }
                
        }

        private void btnAjoutBalise_Click(object sender, EventArgs e)
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