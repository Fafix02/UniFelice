using System.Xml;

namespace UniFelice.Models.Xml
{
    public class XmlStudente : IStudente
    {
        private readonly XmlNode nodo;
        public XmlStudente(XmlNode nodo)
        {
            this.nodo = nodo;
        }
        public string Matricola 
        { 
            get
            {
                return nodo.Attributes["matricola"].InnerText;
            }
        }
        public string NomeCompleto
        {
            get
            {
                string nome = nodo.SelectSingleNode("name").InnerText;
                return nome;
            }
        }
    }
}
