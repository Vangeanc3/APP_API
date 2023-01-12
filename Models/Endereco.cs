using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        public string Apartamento { get; set; }
        [JsonIgnore]
        public virtual Usuario? Usuario { get; set; }
    }
}