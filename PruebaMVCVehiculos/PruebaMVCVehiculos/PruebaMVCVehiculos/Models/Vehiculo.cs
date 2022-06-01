using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMVCVehiculos.Models
{
    public class Vehiculo
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo codigo es obligatorio")]
        public string codigo { get; set; }

        [Required(ErrorMessage = "El campo chasis es obligatorio")]
        public string chasis { get; set; }

        [Required(ErrorMessage = "El campo marca es obligatorio")]
        public string marca { get; set; }

        [Required(ErrorMessage = "El campo modelo es obligatorio")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "El campo anio_modelo es obligatorio")]
        public int anio_modelo { get; set; }

        [Required(ErrorMessage = "El campo color es obligatorio")]
        public string color { get; set; }

        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string estado { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}
