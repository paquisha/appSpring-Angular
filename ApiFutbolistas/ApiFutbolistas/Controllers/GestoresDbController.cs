using Microsoft.AspNetCore.Mvc;
using ApiFutbolistas.Context;
using Microsoft.EntityFrameworkCore;
using ApiFutbolistas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFutbolistas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresDbController : ControllerBase
    {

        // GET: api/<GestoresDbController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GestoresDbController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GestoresDbController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GestoresDbController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GestoresDbController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
