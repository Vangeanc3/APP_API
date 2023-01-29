namespace APP_API.Data.Dtos.EnderecoDto
{
    public class PutEnderecoDto
    {
        public string? Cep { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }
        public string? Bloco { get; set; }
        public string? Apartamento { get; set; }
    }
}
