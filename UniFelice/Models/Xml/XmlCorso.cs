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
    }
}
