using System;
using System.Collections.Generic;
using System.Linq;
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
        
        /// <summary>
        /// Constructeur d'une balise
        /// </summary>
        /// <param name="pNom">Nom de la balise</param>
        public Balise(string pNom)
        {
            Nom = pNom;
            Attributs = new Dictionary<string, string>();
            Text = ToString();
            IsSelfClosing = new List<string>()
            {
                "area", "base", "br", "col", "command", "embed", "hr", "img", "input", "keygen", "link", "meta",
                "param", "source", "track", "wbr", "script", "meta", "link"
            }.Contains(pNom);
        }

        /// <summary>
        /// Constructeur d'une balise
        /// </summary>
        /// <param name="pNom">Nom de la balise</param>
        /// <param name="pAttributs">Attributs de la balise</param>
        /// <param name="pContenu">Contenu de la balise</param>
        public Balise(string pNom, Dictionary<string, string> pAttributs, string pContenu) : this(pNom)
        {
            _attributs = pAttributs;
            _contenu = pContenu;
            Text = ToString();
        }
        
        /// <summary>
        /// Représentation de la balise sous forme de texte
        /// </summary>
        /// <returns>Une string représentant la balise</returns>
        public sealed override string ToString()
        {
            return "<" + Nom + ">" + " (" + Attributs.Count + " attributs)";
        }

        /// <summary>
        /// Obtenir le tag HTML de la balise
        /// </summary>
        /// <returns>Le tag HTML correspondant à la balise</returns>
        private string ToStringHtml()
        {
            if (IsSelfClosing)
            {
                return $"<{Nom} {string.Join(" ", Attributs.Select(pKv => $"{pKv.Key}=\"{pKv.Value}\"").ToArray())} />";
            }
            return $"<{Nom} {string.Join(" ", Attributs.Select(pKv => $"{pKv.Key}=\"{pKv.Value}\"").ToArray())}>{Contenu}";
        }

        /// <summary>
        /// Chercher une balise ayant un id
        /// </summary>
        /// <param name="pId">L'id de la balise recherché</param>
        /// <returns>La balise ayant l'id ou null</returns>
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

        /// <summary>
        /// Chercher les balises correspondant à un nom
        /// </summary>
        /// <param name="pTag">Le nom de la balise recherché</param>
        /// <returns>Une liste contenant les tags du nom recherché</returns>
        public List<Balise> HasTag(String pTag)
        {
            List<Balise> list = new List<Balise>();

            if (Nom == pTag)
            {
                list.Add(this);
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

        /// <summary>
        /// Obtenir les tags HTML de la balise et de ses enfants
        /// </summary>
        /// <returns>Une list de string contenant les tags html de la balise et de ses descendants</returns>
        public List<string> ToHtml()
        {
            List<string> tags = new List<string>();

            tags.Add(ToStringHtml());

            foreach (Balise balise in Nodes)
            {
                tags.AddRange(balise.ToHtml());
            }

            if (!IsSelfClosing)
            {
                tags.Add($"</{Nom}>");
            }

            return tags;
        }

    }
}