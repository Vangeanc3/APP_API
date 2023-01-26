using System.ComponentModel.DataAnnotations;

namespace APP_API.Data.Dtos.UsuarioDto
{
    public class CreateUsuarioDto
    {
        [Required]
        [MaxLength(35, ErrorMessage = "O nome não exceder 35 caracteres!!!")]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Número de telefone inválido")]
        public string Telefone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } // PK
        [Required]
        public string Senha { get; set; }
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        public string? Cpf { get; set; }  // Pode ser null
    }
}
