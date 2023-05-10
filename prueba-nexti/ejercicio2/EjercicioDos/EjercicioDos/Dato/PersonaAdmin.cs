using EjercicioDos.Modelo;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioDos.Dato
{
    public class PersonaAdmin
    {
        public List<Persona> Consultar()
        {
            using(CrudWFEntities contexto = new CrudWFEntities())
            {
                return contexto.Persona.AsNoTracking().ToList();
            }
        }

        public void Guardar(Persona persona)
        {
            using (CrudWFEntities contexto = new CrudWFEntities())
            {
                contexto.Persona.Add(persona);
                contexto.SaveChanges();
            }
        }
 
    }
}
