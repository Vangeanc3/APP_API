using APP_API.Models;
using System.Text.Json.Serialization;

namespace APP_API.Data.Dtos.LinhaDto
{
    public class ReadLinhaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
