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

        public IActionResult Detail()
        {
            return View();
        }
    }
}
