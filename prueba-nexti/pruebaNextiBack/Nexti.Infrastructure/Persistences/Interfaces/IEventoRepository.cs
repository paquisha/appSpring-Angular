using Nexti.Domain.Entities;
using Nexti.Infrastructure.Commons.Bases.Request;
using Nexti.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Infrastructure.Persistences.Interfaces
{
    public interface IEventoRepository
    {
        Task<BaseEntityResponse<Evento>> ListEvento(BaseFilterRequest filters);
        Task<IEnumerable<Evento>> ListSelectEvento();
        Task<Evento> EventoById(int id);
        Task<bool> RegisterEvento(Evento evento);
        Task<bool> EditEvento(Evento evento);
        Task<bool> RemoveEvento(int id);
    }
}
