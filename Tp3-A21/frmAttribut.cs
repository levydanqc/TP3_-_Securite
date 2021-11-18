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
    public partial class frmAttribut : Form
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

        public frmAttribut()
        {
            InitializeComponent();
        }

        private void btnAjout_Click(object sender, EventArgs e)
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