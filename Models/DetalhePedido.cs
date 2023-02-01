using System.Text.Json.Serialization;

namespace APP_API.Models
{
    public class DetalhePedido
    {
        [JsonIgnore]
        public int PedidoId { get; set; }
        [JsonIgnore]
        public virtual Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
        public int QuantProduto { get; set; }
    }
}
