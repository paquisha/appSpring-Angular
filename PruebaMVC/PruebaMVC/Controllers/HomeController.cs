using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaMVC.Models;
using PruebaMVC.Models.ViewModels;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace PruebaMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DBCRUDCOREContext _dbcontext;

        public HomeController(DBCRUDCOREContext context)
        {
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] CompraViewModel oCompraViewModel)
        {
            Cabecera Ocabecera = oCompraViewModel.oCabecera;

            _dbcontext.Cabeceras.Add(Ocabecera);
            _dbcontext.SaveChanges();

            return Json(new { respuesta = true });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}