namespace APP_API.Models
{
    public class DetalheOrcamento
    {
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int QuantProdutos { get; set; }
        public int OrcamentoId { get; set; }
        public virtual Orcamento Orcamento { get; set; }
    }
}