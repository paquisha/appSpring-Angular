using System.ComponentModel.DataAnnotations;

namespace AutoresPruebas.DTOs
{
    public class ActualizarRestriccionIPDTO
    {
        [Required]
        public string IP { get; set; }
    }
}
