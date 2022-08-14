using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tecgraf.Dpara;
using Tecgraf.Model;
using Tecgraf.Serial;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        } 

        public IActionResult VerificarSerial()
        {
            return View();
        }


        public IActionResult GerarSerial(SerialNumber serie)
        {
            SerialNumber serial = new Resolve().getSerial(serie);
            var listPais = Pais.getInstancia().getAll();
            var listTipo = Enum.GetValues(typeof(TipoAutomovel)).Cast<TipoAutomovel>();

            ViewBag.Tipo = listTipo.Select((r, i) => new SelectListItem { Text = r.ToString(), Value = i.ToString() });
            ViewBag.Pais = listPais.Select((r, i) => new SelectListItem { Text = $"{r.Value} - {r.Key}", Value = r.Key });

            if (serial != null)
                return View(serial);

            var serialNumber = new SerialNumber(); 
            serialNumber.AnoFabricacao = DateTime.Now.ToString("yyyy");
            serialNumber.AnoModelo = DateTime.Now.ToString("yyyy");
           
            return View(serialNumber);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
