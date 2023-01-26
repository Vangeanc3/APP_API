using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using APP_API.Models;

namespace APP_API.Data.Dtos.DetalheOrcamentoDto
{
    public class ReadDetalheOrcamentoDto
    {
        public virtual Produto Produto { get; set; }
        public int QuantProdutos { get; set; }
    }
}