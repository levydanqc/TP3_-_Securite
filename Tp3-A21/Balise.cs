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

        public Balise FindById(String pId)
        {
            if (Attributs.ContainsKey("id") && Attributs["id"] == pId)
            {
                return this;
            }
            
            foreach (Balise node in Nodes)
            {
                Balise tempo = node.FindById(pId);
                if (tempo != null) return tempo;
            }

            return null;
        }

        public List<Balise> HasTag(String pTag)
        {
            List<Balise> list = new List<Balise>();

            if (Nodes.Count == 0)
            {
                if (Nom == pTag)
                {
                    list.Add(this);
                }
            }
            else
            {
                foreach (Balise balise in Nodes)
                {
                    list.AddRange(balise.HasTag(pTag));
                }    
            }

            return list;
        }
    }
}