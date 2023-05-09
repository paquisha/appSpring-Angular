using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaracion o matricula de nuestras interfaces a nivel de repository
        IEventoRepository Category { get; }
        void SaveChange();
        Task SaveChangesAsync();
    }
}
