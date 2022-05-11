using System.Diagnostics;
using System.Xml;
using UniFelice.Models.Xml;

namespace UniFelice.Models.xml
{
    public class XmlArchivio : IArchivio
    {
        private readonly string percorso;
        private XmlDocument Doc
        {
            get
            {
                XmlDocument doc = new();
                doc.Load(percorso);
                return doc;
            }
        }
        public XmlArchivio(string percorso)
        {
            this.percorso = percorso;
        }
        public List<IStudente> Studenti
        {
            get
            {
                string pattern = "uni/studente";
                XmlNodeList nodi = Doc.SelectNodes(pattern);
                List<IStudente> daRitornare = new();
                foreach(XmlNode nodo in nodi)
                {
                    daRitornare.Add(new XmlStudente(nodo));
                }
                return daRitornare;
            }
        }
    }
}
