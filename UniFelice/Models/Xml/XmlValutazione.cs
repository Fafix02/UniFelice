using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlValutazione : IValutazione
    {
        private readonly XmlNode nodo;
        public XmlValutazione(XmlNode nodo)
        {
            this.nodo = nodo;
        }
        public string Appello => nodo.Attributes["appello"].Value;

        public int Voto => int.Parse(nodo.InnerText);
    }
}
