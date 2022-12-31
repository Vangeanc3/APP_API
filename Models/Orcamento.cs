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
        public int Identificador { get; set; }
        public Instalador Instalador { get; set; }
        public List<Produto> Produtos { get; set; }
        public int QuantProdutos { get; set; }
        public string? Servico { get; set; }
    }
}