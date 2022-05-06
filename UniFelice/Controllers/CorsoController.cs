using Microsoft.AspNetCore.Mvc;
using UniFelice.Models;
using UniFelice.Models.Xml;

namespace UniFelice.Controllers
{
    public class CorsoController : Controller
    {
        private readonly IArchivioCorsi archive;

        public CorsoController()
        {
            string percorsoArchivio = Directory.GetCurrentDirectory() + @"/Data/unifelice.xml";
            archive = new XmlArchivioCorsi(percorsoArchivio);
        }

        public IActionResult Index()
        {
            return View(archive.Corsi);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult Detail(string id)
        {
            foreach (ICorsoLaurea c in archive.Corsi)
            {
                if (c.Codice == id)
                {
                    return View(c);
                }
            }
            return BadRequest($"Errore corso con codice {id} non trovato");
        }
    }
}
