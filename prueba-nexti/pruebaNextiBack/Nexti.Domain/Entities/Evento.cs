using System;
using System.Collections.Generic;

namespace Nexti.Domain.Entities
{
    public partial class Evento
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Lugar { get; set; }
        public int? Numero { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }
}
