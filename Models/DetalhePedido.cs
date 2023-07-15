using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class DetalhePedido
    {
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; } = null!;
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; } = null!;
        public int QuantProduto { get; set; }
    }
}