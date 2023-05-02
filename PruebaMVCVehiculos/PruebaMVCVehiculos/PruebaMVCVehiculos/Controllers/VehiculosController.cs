using Microsoft.AspNetCore.Mvc;
using PruebaMVCVehiculos.Datos;
using PruebaMVCVehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMVCVehiculos.Controllers
{
    public class VehiculosController : Controller
    {
        VehiculoDatos vehiculodatos = new VehiculoDatos();

        public IActionResult Listar()
        {
            var oLista = vehiculodatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            vehiculo.fecha_registro = DateTime.Now;
            var respuesta = vehiculodatos.Guardar(vehiculo);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int id)
        {
            var oVehiculo = vehiculodatos.ObtenerPorId(id);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Editar(Vehiculo oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            oVehiculo.fecha_registro = DateTime.Now;
            var respuesta = vehiculodatos.Editar(oVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int id)
        {
            var oVehiculo = vehiculodatos.ObtenerPorId(id);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Eliminar(Vehiculo oVhehiculo)
        {

            var respuesta = vehiculodatos.eliminar(oVhehiculo.id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
