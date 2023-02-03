using APP_API.Models;
using System.Text.Json.Serialization;

namespace APP_API.Data.Dtos.EnderecoDto
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Bloco { get; set; }
        public string Apartamento { get; set; }
        public object Usuario { get; set; } // Dono do endereco
    }
}
