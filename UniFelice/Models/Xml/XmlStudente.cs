using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlStudente : IStudente
    {
        private readonly XmlNode nodo;
        public XmlStudente(XmlNode nodo)
        {
            this.nodo = nodo;
        }
        public string Matricola
        {
            get
            {
                return nodo.Attributes["matricola"].InnerText;
            }
        }
        public string NomeCompleto
        {
            get
            {
                string nome = nodo.SelectSingleNode("name").InnerText;
                return nome;
            }
        }

        public string CorsoIscritto => nodo.SelectSingleNode("iscritto").InnerText;

        public List<IValutazione> Libretto
        {
            get
            {
                List<IValutazione> toReturn = new();
                string pattern = "libretto/valutazione";
                XmlNodeList nodes = nodo.SelectNodes(pattern);
                foreach (XmlNode n in nodes)
                {
                    toReturn.Add(new XmlValutazione(n));
                }
                return toReturn;
            }
        }
    }
}
