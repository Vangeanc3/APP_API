using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class Produto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoParceiro { get; set; } // Preciso de detalhes
        public double PrecoCliente { get; set; } // Preciso de detalhes
        public string LinkImg { get; set; }
        public string LinkPdfManual { get; set; }
        public Categoria Categoria { get; set; } // Preciso de detalhes
        public ICollection<Orcamento>? Orcamentos { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }

    }

    public enum Categoria
    {
        Digital,
        Fisico
    }
}