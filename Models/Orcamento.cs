using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP_API.Models
{
    public class Orcamento  // Depende de produtos
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string IdentificadorUnico { get; set; } = null!;
        public string NomeCliente { get; set; } = null!;// Nome do Cliente que fez o Orcamento
        public string DescricaoServico { get; set; } = null!;
        public double PrecoServico { get; set; }
        public double PrecoFinal { get; set; }
        public int InstaladorId { get; set; } // FK do Instalador 1 - N
        public virtual Usuario Instalador { get; set; } = null!; // Instalador que vai fazer o orcamento
        public virtual ICollection<DetalheOrcamento> DetalhesOrcamentos { get; set; } = null!; // Produtos do orcamento
    }
}

