using BGRPrueba.DBContexts;
using BGRPrueba.Model;

namespace BGRPrueba.Repository;

public class PersonaRepository : IPersonaRepository
{
    private readonly AppDBContext _dbContext;

    public PersonaRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Persona> GetPersona()
    {
        return _dbContext.Personas.ToList();
    }

    public Persona GetPersonaByCI(string ci)
    {
        return _dbContext.Personas.FirstOrDefault(p => p.cedula == ci);
    }
}