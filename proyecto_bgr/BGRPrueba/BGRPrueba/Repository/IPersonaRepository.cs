using BGRPrueba.Model;

namespace BGRPrueba.Repository;

public interface IPersonaRepository
{
    IEnumerable<Persona> GetPersona();

    Persona GetPersonaByCI(string ci);
}