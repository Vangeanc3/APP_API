using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Categoria
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Linha> Linhas { get; set; }

        [JsonIgnore]
        public virtual List<Produto> Produtos { get; set; }
    }
}
