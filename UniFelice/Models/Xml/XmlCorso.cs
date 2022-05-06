using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlCorso : ICorsoLaurea
    {
        private readonly XmlNode node;
        public XmlCorso(XmlNode node)
        {
            this.node = node;
        }
        public string Codice => node.Attributes["codice"].InnerText;

        public string Descrizione => node.SelectSingleNode("descrizione").InnerText;

        public List<string> CodEsami
        {
            get
            {
                List<string> toReturn = new ();
                string path = "esame";
                XmlNodeList nodes = node.SelectNodes(path);
                foreach (XmlNode node in nodes)
                {
                    toReturn.Add(node.Attributes["codice"].InnerText);
                }
                return toReturn;
            }
        }
    }
}
