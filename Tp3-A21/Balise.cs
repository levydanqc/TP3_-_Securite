using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp3_A21
{
    public class Balise : TreeNode
    {
        private string _nom;
        private Dictionary<string, string> _attributs;
        private string _contenu;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Dictionary<string, string> Attributs
        {
            get { return _attributs; }
            set { _attributs = value; }
        }

        public string Contenu
        {
            get { return _contenu; }
            set { _contenu = value; }
        }

        public Balise(string pNom)
        {
            Nom = pNom;
            Attributs = new Dictionary<string, string>();
            Text = ToString();
        }

        public Balise(string pNom, Dictionary<string, string> pAttributs, string pContenu) : this(pNom)
        {
            _attributs = pAttributs;
            _contenu = pContenu;
            Text = ToString();
        }

        public override string ToString()
        {
            return "<" + Nom + ">" + " (" + Attributs.Count + " attributs)";
        }
    }
}