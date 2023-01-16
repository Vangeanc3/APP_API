using System.ComponentModel.DataAnnotations;

namespace APP_API.Data.Dtos.UsuarioDto
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Telefone { get; set; }
        [Key]
        [Required]
        public string Email { get; set; } // PK
        [Required]
        public string Senha { get; set; }
        public string? Cpf { get; set; }  // Pode ser null
        public Guid EnderecoId { get; set; } // Endereço FK
    }
}
