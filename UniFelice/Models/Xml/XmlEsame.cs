using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlEsame : IEsame
    {
        private readonly XmlNode node;

        public XmlEsame(XmlNode node)
        {
            this.node = node;
        }

        public string Codice => node.Attributes["codice"].InnerText;

        public List<string> Assistenti
        {
            get
            {
                List<string> toReturn = new();
                string pattern = "assistente";
                XmlNodeList nodes = node.SelectNodes(pattern);
                foreach (XmlNode n in nodes)
                {
                    toReturn.Add(n.InnerText);
                }
                return toReturn;
            }
        }

        public List<IAppello> Appelli
        {
            get
            {
                List<IAppello> toReturn = new();
                string pattern = "appello";
                XmlNodeList nodes = node.SelectNodes(pattern);
                foreach (XmlNode n in nodes)
                {
                    toReturn.Add(new XmlAppello(n));
                }
                return toReturn;
            }
        }

        public string? Descrizione => "k";//node.SelectSingleNode("descrizione").InnerText;

        public string Titolare => "p";//node.SelectSingleNode("titolare").InnerText;
    }
}
