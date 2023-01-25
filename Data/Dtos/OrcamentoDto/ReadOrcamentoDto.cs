using APP_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public virtual Usuario Instalador { get; set; } // Instalador que vai fazer o orcamento
        public virtual ICollection<DetalheOrcamento> DetalhesOrcamentos { get; set; } // Produtos do orcamento
    }
}
