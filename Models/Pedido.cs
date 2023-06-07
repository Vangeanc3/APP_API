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
        public int Id { get; set; }
        public string Identificador { get; set; } = null!; // FK
        public string EntregaOpcao { get; set; } = null!; // Definir depois!!!
        public FormaDePagamento FormaDePagamento { get; set; } // Select
        public double Preco { get; set; }
        public int InstaladorId { get; set; } // FK Instalador
        public virtual Usuario Instalador { get; set; } = null!; // Pode ter como origem opcao1
        public virtual ICollection<DetalhePedido> DetalhePedidos { get; set; } = null!; // Lista de produtos

    }

    public enum FormaDePagamento
    {
        CartaoCredito = 1,
        CartooDebito = 2,
        Dinheiro = 3
    }
}