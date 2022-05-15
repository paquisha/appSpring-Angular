using System.ComponentModel.DataAnnotations;

namespace AutoresPruebas.DTOs
{
    public class CrearRestriccionIPDTO
    {
        public int LlaveId { get; set; }
        [Required]
        public string IP { get; set; }
    }
}
