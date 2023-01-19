using APP_API.Data.Dtos.LinhaDto;
using APP_API.Models;

namespace APP_API.Data.Dtos.CategoriaDto
{
    public class ReadLinhaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Linha> Linhas { get; set; }
    }
}
