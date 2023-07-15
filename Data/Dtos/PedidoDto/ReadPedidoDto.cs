using APP_API.Models;

namespace APP_API.Data.Dtos.PedidoDto
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public string Identificador { get; set; } // FK
        public string EntregaOpcao { get; set; } // Definir depois!!!
        public FormaDePagamento FormaDePagamento { get; set; } // Select
        public double Preco { get; set; }
        public object Instalador { get; set; } // Pode ter como origem opcao1
        public object DetalhePedidos { get; set; } // Lista de produtos

    }
}
