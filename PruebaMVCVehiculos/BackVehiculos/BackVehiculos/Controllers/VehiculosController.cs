using BackVehiculos.Context;
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
        private readonly AppDbContext _context;

        public VehiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Vehiculos.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetVehiculo")]
        public ActionResult Get(int id)
        {
            try
            {
                var vehiculo = _context.Vehiculos.FirstOrDefault(f => f.id == id);
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            try
            {
                _context.Vehiculos.Add(vehiculo);
                _context.SaveChanges();
                return CreatedAtRoute("GetVehiculo", new { id = vehiculo.id }, vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Vehiculo vehiculo)
        {
            try
            {
                if (vehiculo.id == id)
                {
                    _context.Entry(vehiculo).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetVehiculo", new { id = vehiculo.id }, vehiculo);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var vehiculo = _context.Vehiculos.FirstOrDefault(f => f.id == id);
                if (vehiculo != null)
                {
                    _context.Vehiculos.Remove(vehiculo);
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
