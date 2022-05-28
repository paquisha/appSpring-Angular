using CrudMVCCore.Datos;
using CrudMVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVCCore.Controllers
{
    public class ContactosController : Controller
    {
        ContactoDatos contactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //mostrar vista lista contactos
            var oLista = contactoDatos.Listar();
            return View(oLista); 
        }

        public IActionResult Guardar()
        {
            //devuelve vista cshtml
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Contacto contacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //recibe objeto para guardar en el db
            var respuesta = contactoDatos.Guardar(contacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = contactoDatos.ObtenerPorId(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(Contacto oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = contactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = contactoDatos.ObtenerPorId(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(Contacto oContacto)
        {

            var respuesta = contactoDatos.eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
