using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using UniFelice.Models;
using UniFelice.Models.xml;
using UniFelice.Models.Xml;

namespace UniFelice.Controllers
{
    public class StudenteController : Controller
    {
        private readonly IArchivio archivio;
        private readonly IArchivioCorsi corsi;
        public StudenteController()
        {
            string percorsoArchivio = Directory.GetCurrentDirectory() + @"/Data/unifelice.xml";
            archivio = new XmlArchivio(percorsoArchivio);
            corsi = new XmlArchivioCorsi(percorsoArchivio);
        }

        public IActionResult Index()
        {
            return View(archivio.Studenti);
        }

        [HttpGet("Dettaglio/{id}")]
        public IActionResult Dettaglio(string id)
        {
            foreach(IStudente s in archivio.Studenti)
            {
                if(s.Matricola == id)
                {
                    return View(s);
                }
            }
            return BadRequest($"Errore studente con matricola {id} non trovato");
        }

        public IActionResult Create()
        {
            return View("Create", string.Empty);
        }

        [HttpPost]
        public IActionResult Success([FromForm] string Matricola, [FromForm] string NomeCognome, [FromForm] string Corso)
        {
            bool check = false;
            foreach (ICorsoLaurea corso in corsi.Corsi)
            {
                if (corso.Codice == Corso)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                return View("Create", $"Errore non esiste un corso con codice {Corso}");
            }
            XmlDocument doc = new();
            doc.LoadXml(Directory.GetCurrentDirectory() + @"/Data/unifelice.xml");
            XmlElement XEle = doc.CreateElement("stu");
            XEle.SetAttribute("matricola", Matricola);
            doc.AppendChild(XEle);
            doc.Save(Directory.GetCurrentDirectory() + @"/Data/unifelice.xml");
            return View();
        }
    }
}
