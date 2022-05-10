using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlProfessore : IProfessore
    {
        private readonly XmlNode node;

        public XmlProfessore(XmlNode node)
        {
            this.node = node;
        }

        public string Codice => node.Attributes["codice"].InnerText;

        public string NomeCompleto => node.InnerText;
    }
}
