using System.ComponentModel.DataAnnotations;

namespace APP_API.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Linha> Linhas { get; set; }
    }
}
