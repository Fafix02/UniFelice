using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlAppello : IAppello
    {
        private readonly XmlNode node;
        public XmlAppello(XmlNode node, string codEsame)
        {
            this.node = node;
            CodEsame = codEsame;
        }
        public DateTime Data
        {
            get
            {
                string txt = node.SelectSingleNode("data").InnerText;
                string[] single = txt.Split('-');
                return new DateTime(int.Parse(single[0]), int.Parse(single[1]), int.Parse(single[2]));
            }
        }

        public IAppello.Tipo TipoAppello
        {
            get
            {
                if (node.SelectSingleNode("tipo").InnerText.ToLower() == "scritto")
                {
                    return IAppello.Tipo.SCRITTO;
                }
                else if (node.SelectSingleNode("tipo").InnerText.ToLower() == "orale")
                {
                    return IAppello.Tipo.ORALE;
                }
                return IAppello.Tipo.MISTO;
            }
        }

        public string CodEsame { get; set; }

        public string Codice => node.Attributes["codice"].InnerText;
    }
}
