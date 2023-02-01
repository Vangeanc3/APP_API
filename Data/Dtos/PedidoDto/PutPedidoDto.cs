using APP_API.Data.Dtos.ProdutoPedidoDto;
using APP_API.Models;

namespace APP_API.Data.Dtos.PedidoDto
{
    public class PutPedidoDto
    {

        public string? EntregaOpcao { get; set; } // Definir depois!!!
        public FormaDePagamento? FormaDePagamento { get; set; } // Select
        public double? Preco { get; set; }
        public int? InstaladorId { get; set; } // FK Instalador
        public List<ProdutoPedido>? ProdutosDoPedido { get; set; }
    }
}
