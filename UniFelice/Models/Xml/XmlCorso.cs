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

        public List<IEsame> Esami
        {
            get
            {
                List<IEsame> toReturn = new ();
                string path = "esame";
                XmlNodeList nodes = node.SelectNodes(path);
                foreach (XmlNode n in nodes)
                {
                    toReturn.Add(new XmlEsame(n));
                }
                return toReturn;
            }
        }
    }
}
