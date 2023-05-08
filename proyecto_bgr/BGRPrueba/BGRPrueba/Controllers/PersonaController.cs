using BGRPrueba.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BGRPrueba.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
    private readonly IPersonaRepository _personaRepository;

    public PersonaController(IPersonaRepository personaRepository)
    {
        _personaRepository = personaRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var personas = _personaRepository.GetPersona();
            return new OkObjectResult(personas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{ci}", Name = "Get")]
    public IActionResult GetByData(string ci)
    {
        try
        {
            var persona = _personaRepository.GetPersonaByCI(ci);
            return new OkObjectResult(persona);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}