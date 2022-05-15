using System.ComponentModel.DataAnnotations;

namespace AutoresPruebas.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
