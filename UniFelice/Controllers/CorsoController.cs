using Microsoft.AspNetCore.Mvc;
using UniFelice.Models;
using UniFelice.Models.Archives;
using UniFelice.Models.Xml;

namespace UniFelice.Controllers
{
    public class CorsoController : Controller
    {
        private readonly IArchivioCorsi archive;
        private readonly IArchivioEsami esami;

        public CorsoController()
        {
            string percorsoArchivio = Directory.GetCurrentDirectory() + @"/Data/unifelice.xml";
            archive = new XmlArchivioCorsi(percorsoArchivio);
            esami = new XmlArchivioEsami(percorsoArchivio);
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

        public IActionResult Esami()
        {
            return View(esami.Esami);
        }
    }
}
