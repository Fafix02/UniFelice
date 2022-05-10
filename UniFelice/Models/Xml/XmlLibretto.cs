using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlLibretto : ILibretto
    {
        private readonly XmlNode nodo;
        public XmlLibretto(XmlNode nodo)
        {
            this.nodo = nodo;
        }

        public List<IValutazione> Voti
        {
            get
            {
                List<IValutazione> toReturn = new();
                string pattern = "valutazione";
                XmlNodeList nodes = nodo.SelectNodes(pattern);
                foreach (XmlNode n in nodes)
                {
                    toReturn.Add(new XmlValutazione(n));
                }
                return toReturn;
            }
        }

        public string Formato => nodo.Attributes["type"].InnerText.ToLower();

        public ILibretto.Tipo Type
        {
            get
            {
                if (Formato == "cartaceo") {
                    return ILibretto.Tipo.CARTACEO;
                }
                else if(Formato == "digitale")
                {
                    return ILibretto.Tipo.DIGITALE;
                }
                return ILibretto.Tipo.SCONOSCIUTO;
            }
        }
    }
}
