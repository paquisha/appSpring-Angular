using Microsoft.EntityFrameworkCore;
using Nexti.Domain.Entities;
using Nexti.Infrastructure.Commons.Bases.Request;
using Nexti.Infrastructure.Commons.Bases.Response;
using Nexti.Infrastructure.Persistences.Contexts;
using Nexti.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Infrastructure.Persistences.Repositories
{
    internal class EventoRepository : GenericRepository<Evento>, IEventoRepository
    {
        private readonly pruebaNextiContext _context;

        public EventoRepository(pruebaNextiContext context)
        {
            _context = context;
        }

        public async Task<bool> EditEvento(Evento evento)
        {
            _context.Update(evento);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;

        }

        public async Task<Evento> EventoById(int id)
        {
            var evento = await _context.Eventos!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return evento!;
        }

        public Task<BaseEntityResponse<Evento>> ListEvento(BaseFilterRequest filters)
        {
            //var reponse = new BaseEntityResponse<Evento>();
            //var eventos = (from c in _context.Eventos
            //               where c.Numero == 1
            //               select c
            //               ).AsNoTracking().AsQueryable();

            //reponse.TotalRecords = await eventos.CountAsync();
            //reponse.Items = await Ordering(filters, eventos, !(bool)filters.Download).ToListAsync();

            //return reponse;
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Evento>> ListSelectEvento()
        {
            var eventos = await _context.Eventos.AsNoTracking().ToListAsync();
            return eventos;
        }

        public async Task<bool> RegisterEvento(Evento evento)
        {
            evento.Fecha = DateTime.Now;
            await _context.AddAsync(evento);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> RemoveEvento(int id)
        {
            var evento = await _context.Eventos.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
            _context.Remove(evento!);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
