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

        public void Add(string matr, string fullName, string course)
        {
            XmlElement XEle = Doc.CreateElement("studente");
            XEle.SetAttribute("matricola", matr);

            var importNode = Doc.ImportNode(XEle, true);
            Doc.AppendChild(importNode);

            Doc.Save(percorso);
        }
    }
}
