using Nexti.Infrastructure.Persistences.Contexts;
using Nexti.Infrastructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly pruebaNextiContext _context;
        public IEventoRepository Category { get; private set; }

        public UnitOfWork(pruebaNextiContext context)
        {
            _context = context;
            Category = new EventoRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
