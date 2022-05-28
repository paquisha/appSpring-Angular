using Microsoft.AspNetCore.Mvc;

namespace CrudMVCCore.Controllers
{
    public class ContactosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
