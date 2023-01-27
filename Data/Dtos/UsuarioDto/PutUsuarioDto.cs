using System.ComponentModel.DataAnnotations;

namespace APP_API.Data.Dtos.UsuarioDto
{
    public class PutUsuarioDto
    {
        [MaxLength(35, ErrorMessage = "O nome não pode exceder 35 caracteres!!!")]
        public string? Nome { get; set; }
        [RegularExpression(@"^\d{2}-\d{5}-\d{4}$", ErrorMessage = "Número de telefone inválido")]
        public string? Telefone { get; set; }
        [EmailAddress]
        public string? Email { get; set; } // PK
        public string? Senha { get; set; }
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        public string? Cpf { get; set; }  // Pode ser null
    }
}
