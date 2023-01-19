using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APP_API.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public string Identificador { get; set; } // FK
        public string EntregaOpcao { get; set; } // Definir depois!!!
        public FormaDePagamento FormaDePagamento { get; set; } // Select
        public double Preco { get; set; }
        public int InstaladorId { get; set; } // FK Instalador
        public virtual Usuario Instalador { get; set; } // Pode ter como origem opcao1
        public virtual ICollection<Produto>? Produtos { get; set; } // Lista de produtos

    }

    public enum FormaDePagamento
    {
        CartaoCredito,
        CartooDebito,
        Dinheiro
    }
}