//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace APP_API.Models
//{
//    public class Orcamento
//    {
//        [Key]
//        public string Identificador { get; set; }
//        public string EmailInstalador { get; set; } // Instalador FK
//        public Instalador Instalador { get; set; } // Instalador
//        public string EmailCliente { get; set; } // Cliente FK
//        public Cliente Cliente { get; set; }
//        public List<Produto> Produtos { get; set; }
//        public int QuantProdutos { get; set; }
//        public string? Servico { get; set; }
//    }
//}