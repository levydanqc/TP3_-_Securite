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
        private bool _isSelfClosing;

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

        public bool IsSelfClosing
        {
            get { return _isSelfClosing; }
            set { _isSelfClosing = value; }
        }

        public Balise(string pNom)
        {
            Nom = pNom;
            Attributs = new Dictionary<string, string>();
            Text = ToString();
            IsSelfClosing = new List<string>()
            {
                "area", "base", "br", "col", "command", "embed", "hr", "img", "input", "keygen", "link", "meta",
                "param", "source", "track", "wbr"
            }.Contains(pNom);
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

        public string ToStringHTML()
        {
            if (IsSelfClosing)
            {
                return $"<{Nom} {string.Join(" ", Attributs.Select(pKV => $"{pKV.Key}=\"pKV.Value\"").ToArray())} />";
            }
            return $"<{Nom} {string.Join(" ", Attributs.Select(pKV => $"{pKV.Key}=\"pKV.Value\"").ToArray())}>{Contenu}</{Nom}>";
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

        public List<string> ToHTML()
        {
            List<string> tags = new List<string>();

            if (Nodes.Count == 0)
            {
                tags.Add(ToStringHTML());
            }
            else
            {
                foreach (Balise balise in Nodes)
                {
                    tags.AddRange(balise.ToHTML());
                }
            }

            return tags;
        }

    }
}