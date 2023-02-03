using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        public string Apartamento { get; set; }
        public int  UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}