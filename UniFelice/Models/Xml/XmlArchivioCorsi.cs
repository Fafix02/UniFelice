using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlArchivioCorsi : IArchivioCorsi
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
        public XmlArchivioCorsi(string percorso)
        {
            this.percorso = percorso;
        }
        public List<ICorsoLaurea> Corsi 
        { 
            get
            {
                string pattern = "uni/corso";
                List<ICorsoLaurea> toReturn = new();
                XmlNodeList nodes = Doc.SelectNodes(pattern);
                foreach (XmlNode node in nodes)
                {
                    toReturn.Add(new XmlCorso(node));
                }

                return toReturn;
            } 
        }
    }
}
