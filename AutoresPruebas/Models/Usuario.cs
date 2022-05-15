using Microsoft.AspNetCore.Identity;

namespace AutoresPruebas.Models
{
    public class Usuario : IdentityUser
    {
        public bool MalaPaga { get; set; }
    }
}
