using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using UniFelice.Models;
using UniFelice.Models.Archives.Xml;
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
            foreach (IStudente s in archivio.Studenti)
            {
                if (s.Matricola == id)
                {
                    return View(s);
                }
            }
            return BadRequest($"Errore studente con matricola {id} non trovato");
        }

        #region Create Studente
        public IActionResult Create()
        {
            return View("Create", string.Empty);
        }

        [HttpPost]
        public IActionResult Success([FromForm] string Matricola, [FromForm] string NomeCognome, [FromForm] string Corso)
        {
            if (Matricola == null || NomeCognome == null || Corso == null)
            {
                return View("Create", $"Errore! compilare tutti i campi {Corso}");
            } 
            if (Matricola.Length < 4)
            {
                return View("Create", "Errore! la matricola deve essere composta da minimo 3 caratteri");
            }
            Corso = Corso.ToUpper();
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
                return View("Create", $"Errore! non esiste un corso con codice {Corso}");
            }
            AddXmlData.Add(Matricola, NomeCognome, Corso, Directory.GetCurrentDirectory() + @"/Data/unifelice.xml");
            return View("Success", Matricola);
        }
        #endregion

        #region AddExam
        public IActionResult Register()
        {
            return View("Register", string.Empty);
        }

        [HttpPost]
        public IActionResult Check([FromForm] string Matricola, [FromForm] int VotoValutazione, [FromForm] string CodAppello)
        {
            if (Matricola == null || CodAppello == null)
            {
                return View("Register", "Errore! compilare tutti i campi");
            }
            bool check = false;
            foreach (IStudente studente in archivio.Studenti)
            {
                if (studente.Matricola == Matricola)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                return View("Register", $"Errore la matricola inserita ({Matricola}) non esiste");
            }
            if (VotoValutazione > 33 || VotoValutazione < 18)
            {
                return View("Register", $"Errore la valutazione inserita ({VotoValutazione}) non è valida");
            }
            AddXmlData.AddValutazione(Matricola, VotoValutazione, CodAppello, Directory.GetCurrentDirectory() + @"/Data/unifelice.xml");
            return View("Check", Matricola);
        }
        #endregion
    }
}
