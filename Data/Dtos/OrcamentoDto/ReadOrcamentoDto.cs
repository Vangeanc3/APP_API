using APP_API.Models;

namespace APP_API.Data.Dtos.OrcamentoDto
{
    public class ReadOrcamentoDto
    {
        public int Id { get; set; }
        public string IdentificadorUnico { get; set; }
        public string NomeCliente { get; set; } // Nome do Cliente que fez o Orcamento
        public string DescricaoServico { get; set; }
        public double PrecoServico { get; set; }
        public double PrecoFinal { get; set; }
        public object Instalador { get; set; } // Instalador que vai fazer o orcamento
        public object DetalhesOrcamentos { get; set; } // Produtos do orcamento
    }
}
