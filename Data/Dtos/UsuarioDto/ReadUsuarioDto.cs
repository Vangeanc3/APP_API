using APP_API.Models;
using System.Text.Json.Serialization;

namespace APP_API.Data.Dtos.UsuarioDto
{
    public class ReadUsuarioDto
    {
        public int Id { get; set; } // PK
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; } // Unica 
        public Role Role { get; set; } // Profissao
        public string? Cpf { get; set; }  // Pode ser null
        public bool Status { get; set; } = true;
        public object Enderecos { get; set; } // Endereços e pode ser null
    }
}
