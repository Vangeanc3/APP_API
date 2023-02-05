using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Cep { get; set; } = null!;
        public string Rua { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public int Numero { get; set; }
        public string Bloco { get; set; } = null!;
        public string Apartamento { get; set; } = null!;
        public int  UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}