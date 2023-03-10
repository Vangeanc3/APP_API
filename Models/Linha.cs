using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Linha
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
        [JsonIgnore]
        public virtual List<Produto> Produtos { get; set; }

    }
}
