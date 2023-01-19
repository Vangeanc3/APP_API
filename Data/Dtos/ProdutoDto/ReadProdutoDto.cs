using APP_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APP_API.Data.Dtos.ProdutoDto
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoParceiro { get; set; } // Preciso de detalhes
        public double PrecoCliente { get; set; } // Preciso de detalhes
        public string LinkImg { get; set; }
        public string LinkPdfManual { get; set; }
        public virtual Categoria Categoria { get; set; }
        //public virtual Linha? Linha { get; set; } // LINHA
    }
}
