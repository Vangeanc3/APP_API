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
        public int Identificador { get; set; }
        public List<Produto> Produtos { get; set; }
        public double PrecoPedido { get; set; } 
    }
}