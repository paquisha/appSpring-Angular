using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Application.Dtos.Request
{
    public class EventoRequestDto
    {
        public DateTime? Fecha { get; set; }
        public string? Lugar { get; set; }
        public int? Numero { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }
}
