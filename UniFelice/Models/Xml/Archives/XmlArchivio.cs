using System.Diagnostics;
using System.Xml;
using UniFelice.Models.Xml;

namespace UniFelice.Models.xml
{
    public class XmlArchivio : IArchivio
    {
        private readonly string percorso;
        private XmlDocument Doc
        {
            get
            {
                XmlDocument doc = new();
                doc.Load(percorso);
                return doc;
            }
        }
        public XmlArchivio(string percorso)
        {
            this.percorso = percorso;
        }
        public List<IStudente> Studenti
        {
            get
            {
                string pattern = "uni/studente";
                XmlNodeList nodi = Doc.SelectNodes(pattern);
                List<IStudente> daRitornare = new();
                foreach(XmlNode nodo in nodi)
                {
                    daRitornare.Add(new XmlStudente(nodo));
                }
                return daRitornare;
            }
        }

        public void Add(string Matr, string FullName, string Course)
        {
            XmlDocument doc = new();
            doc.Load(percorso);

            XmlNode root = doc.DocumentElement;

            //Create a new node.
            XmlElement student = doc.CreateElement("studente");
            student.SetAttribute("matricola", Matr);
            XmlElement fullName = doc.CreateElement("name");
            fullName.InnerText = FullName;
            student.AppendChild(fullName);
            XmlElement course = doc.CreateElement("iscritto");
            course.InnerText = Course;
            student.AppendChild(course);
            XmlElement libretto = doc.CreateElement("libretto");
            libretto.SetAttribute("type", ILibretto.Tipo.SCONOSCIUTO + "");
            libretto.InnerText = "";
            student.AppendChild(libretto);

            //Add the node to the document.
            root.AppendChild(student);

            Debug.WriteLine("Display the modified XML...\n" + doc);
            doc.Save(percorso);
        }

        public void AddValutazione(string matricola, int valutazione, string codAppello)
        {
            XmlDocument doc = new();
            doc.Load(percorso);

            XmlNode root = doc.DocumentElement;
            XmlNode studenteNode = root.SelectNodes("studente")[0];
            XmlNodeList students = root.SelectNodes("studente");
            foreach (XmlNode student in students)
            {
                if (student.Attributes["matricola"].InnerText == matricola)
                {
                    studenteNode = student;
                }
            }
            XmlNode libretto = studenteNode.SelectSingleNode("libretto");

            //Create a new node.
            XmlElement Score = doc.CreateElement("valutazione");
            Score.InnerText = "" + valutazione;
            Score.SetAttribute("appello", codAppello);
            libretto.AppendChild(Score);

            //Add the node to the document.
            libretto.AppendChild(Score);

            Debug.WriteLine("Display the modified XML...\n" + doc);
            doc.Save(percorso);
        }
    }
}
