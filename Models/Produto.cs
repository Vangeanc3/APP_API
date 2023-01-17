using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoParceiro { get; set; } // Preciso de detalhes
        public double PrecoCliente { get; set; } // Preciso de detalhes
        public string LinkImg { get; set; }
        public string LinkPdfManual { get; set; }
        public int? LinhaId { get; set; } // FK Linha pode ser null
        [Required(ErrorMessage = "Produto tem que ter uma categoria")]
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
        [JsonIgnore]
        public virtual Linha? Linha { get; set; } // LINHA
        [JsonIgnore]
        public virtual ICollection<Orcamento>? Orcamentos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido>? Pedidos { get; set; }

    }
}