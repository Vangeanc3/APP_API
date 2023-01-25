using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP_API.Models
{
    public class DetalheOrcamento
    {
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public virtual Produto Produto { get; set; }
        public int QuantProdutos { get; set; }
        public int OrcamentoId { get; set; }
        [JsonIgnore]
        public virtual Orcamento Orcamento { get; set; }
    }
}