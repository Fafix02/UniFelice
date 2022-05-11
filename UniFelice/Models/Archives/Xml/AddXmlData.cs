using System.Xml;

namespace UniFelice.Models.Archives.Xml
{
    public static class AddXmlData
    {
        public static void Add(string Matr, string FullName, string Course, string percorso)
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

            doc.Save(percorso);
        }

        public static void AddValutazione(string matricola, int valutazione, string codAppello, string percorso)
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

            doc.Save(percorso);
        }
    }
}
