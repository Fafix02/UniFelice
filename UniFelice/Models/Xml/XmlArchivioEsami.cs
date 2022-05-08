using System.Diagnostics;
using System.Xml;
using UniFelice.Models.Archives;

namespace UniFelice.Models.Xml
{
    public class XmlArchivioEsami : IArchivioEsami
    {
        private readonly string path;
        private XmlDocument Doc
        {
            get
            {
                XmlDocument doc = new();
                doc.Load(path);
                return doc;
            }
        }
        public XmlArchivioEsami(string path)
        {
            this.path = path;
        }
        public List<IEsame> Esami
        {
            get
            {
                List<IEsame> toReturn = new();
                string pattern = "uni/esame";
                XmlNodeList nodes = Doc.SelectNodes(pattern);
                foreach (XmlNode node in nodes)
                {
                    toReturn.Add(new XmlEsame(node));
                }
                return toReturn;
            }
        }
    }
}
