using Microsoft.AspNetCore.Mvc;
using Nexti.Application.Dtos.Request;
using Nexti.Application.Interfaces;

namespace Nexti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoApplication _eventoApplication;

        public EventoController(IEventoApplication eventoApplication)
        {
            _eventoApplication = eventoApplication;
        }

        [HttpGet("Select")]
        public async Task<IActionResult> listaEventos()
        {
            var response = await _eventoApplication.ListSelectEventos();
            return Ok(response);
        }

        [HttpGet("{eventoId:int}")]
        public async Task<IActionResult> EventoById(int eventoId)
        {
            var response = await _eventoApplication.EventoById(eventoId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterEvento([FromBody] EventoRequestDto requesDto)
        {
            var response = await _eventoApplication.RegisterEvento(requesDto);
            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<IActionResult> EditaEvento(int id, [FromBody] EventoRequestDto requesDto)
        {
            var response = await _eventoApplication.EditEvento(id, requesDto);
            return Ok(response);
        }

        [HttpDelete("Remove/{id:int}")]
        public async Task<IActionResult> RemoveEvento(int id)
        {
            var response = await _eventoApplication.RemoveEvento(id);
            return Ok(response);

        }
    }
}
