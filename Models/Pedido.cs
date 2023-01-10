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
        public Usuario Instalador { get; set; } // Pode ter como origem opcao1
        public string InstaladorEmail { get; set; } // FK Instalador
        public List<Produto> Produtos { get; set; } // Lista de produtos
        public string EntregaOpcao { get; set; } // Definir depois!!!
        public FormaDePagamento FormaDePagamento { get; set; } // Select
        public double Preco { get; set; }
    }

    public enum FormaDePagamento
    {
        CartaoCredito,
        CartooDebito,
        Dinheiro
    }
}