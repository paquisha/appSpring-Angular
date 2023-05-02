using BackVehiculos.Datos;
using BackVehiculos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackVehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        VehiculoDatos vehiculodatos = new VehiculoDatos();

        [HttpGet]
        public List<Vehiculo> Get()
        {
            return vehiculodatos.Listar();
        }

        [HttpGet("{id}")]
        public Vehiculo Get(int id)
        {
            return vehiculodatos.ObtenerPorId(id);
        }

        [HttpPost]
        public bool Post([FromBody] Vehiculo vehiculo)
        {
            vehiculo.fecha_registro = DateTime.Now;
            return vehiculodatos.Guardar(vehiculo);
        }

        [HttpPut("{id:int}")]
        public bool Put(int id, [FromBody] Vehiculo vehiculo)
        {
            return vehiculodatos.Editar(vehiculo);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return vehiculodatos.eliminar(id);
        }
    }
}
