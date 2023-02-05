using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public int QuantEstoque { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public double PrecoParceiro { get; set; } // Preciso de detalhes
        public double PrecoCliente { get; set; } // Preciso de detalhes
        public string LinkImg { get; set; } = null!;
        public string LinkPdfManual { get; set; } = null!;
        [Required(ErrorMessage = "Produto tem que ter uma categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int? LinhaId { get; set; } // FK Linha pode ser null
        public virtual Linha? Linha { get; set; } // LINHA
        public virtual ICollection<DetalheOrcamento>? DetalheOrcamentos { get; set; }
        public virtual ICollection<DetalhePedido>? DetalhePedidos { get; set; }

    }
}