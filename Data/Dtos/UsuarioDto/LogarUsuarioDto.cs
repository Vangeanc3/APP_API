using System.ComponentModel.DataAnnotations;

namespace APP_API.Data.Dtos.UsuarioDto
{
    public class LogarUsuarioDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
