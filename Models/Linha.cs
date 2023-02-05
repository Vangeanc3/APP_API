using System.ComponentModel.DataAnnotations;

namespace APP_API.Models
{
    public class Linha
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<Produto> Produtos { get; set; }

    }
}
