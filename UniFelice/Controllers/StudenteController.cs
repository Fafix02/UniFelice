using Microsoft.AspNetCore.Mvc;
using UniFelice.Models;
using UniFelice.Models.xml;

namespace UniFelice.Controllers
{
    public class StudenteController : Controller
    {
        private readonly IArchivio archivio;
        public StudenteController()
        {
            string percorsoArchivio = Directory.GetCurrentDirectory() + @"/Data/unifelice.xml";
            archivio = new XmlArchivio(percorsoArchivio);
        }

        public IActionResult Index()
        {
            return View(archivio.Studenti);
        }

        [HttpGet]
        public IActionResult Dettaglio(string id)
        {
            foreach(IStudente s in archivio.Studenti)
            {
                if(s.Matricola == id)
                {
                    return View(id);
                }
            }
            return BadRequest($"Errore studente con matricola {id} non trovato");
        }
    }
}
