namespace APP_API.Data.Dtos.ProdutoDto
{
    public class PutProdutoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int? QuantEstoque { get; set; }
        public double? PrecoParceiro { get; set; } // Preciso de detalhes
        public double? PrecoCliente { get; set; } // Preciso de detalhes
        public string? LinkImg { get; set; }
        public string? LinkPdfManual { get; set; }
        public int? CategoriaId { get; set; }
        public int? LinhaId { get; set; } // FK Linha
    }
}
