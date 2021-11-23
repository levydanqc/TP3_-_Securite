using System;
using System.Windows.Forms;

namespace Tp3_A21
{
    public partial class FrmAttribut : Form
    {
        private string _cle;
        private string _valeur;

        public string Cle
        {
            get { return _cle; }
        }

        public string Valeur
        {
            get { return _valeur; }
        }

        public FrmAttribut()
        {
            InitializeComponent();
        }

        private void btnAjout_Click(object pSender, EventArgs pE)
        {
            if (ValidationNom() && ValidationValeur())
            {
                _cle = txtNom.Text;
                _valeur = txtValeur.Text;
                DialogResult = DialogResult.OK;
                Close();
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

        private bool ValidationValeur()
        {
            if (String.IsNullOrEmpty(txtValeur.Text))
            {
                errorProvider1.SetError(txtValeur, "La valeur ne peut pas être vide");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtValeur, "");
                return true;
            }
        }
    }
}