namespace APP_API.Models
{
    public class DetalhePedido
    {
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int QuantProduto { get; set; }
    }
}
