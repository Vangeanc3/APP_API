using APP_API.Data.Dtos.ProdutoOrcamentoDto;
using APP_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Data.Dtos.OrcamentoDto
{
    public class CreateOrcamentoDto
    {
        public string NomeCliente { get; set; } // Nome do Cliente que fez o Orcamento
        public string DescricaoServico { get; set; }
        public double PrecoServico { get; set; }
        public double PrecoFinal { get; set; }
        public int InstaladorId { get; set; } // FK do Instalador 1 - N
        public List<ProdutoOrcamento> ProdutosDoOrcamento { get; set; } // 
    }
}
