using APP_API.Models;

namespace APP_API.Data.Dtos.DetalhePedidoDto
{
    public class ReadDetalhePedidoDto
    {
        public virtual Produto Produto { get; set; }
        public int QuantProduto { get; set; }
    }
}
