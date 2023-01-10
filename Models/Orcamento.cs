using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP_API.Models
{
    public class Orcamento
    {
        [Key]
        [Required]
        public int Identificador { get; set; }
        public string NomeCliente { get; set; } // Nome do Cliente que fez o Orcamento
        public string DescricaoServico { get; set; }
        public Usuario Instalador { get; set; } // Instalador que vai fazer o orcamento
        public string InstaladorEmail { get; set; } // FK do Instalador 1 - N
        public List<Produto> Produtos { get; set; } // Produtos do orcamento
        public double PrecoFinal { get; set; }
    }
}