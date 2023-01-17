using APP_API.Data.Dtos.LinhaDto;
using APP_API.Models;

namespace APP_API.Data.Dtos.CategoriaDto
{
    public class ReadCategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Linha> Linhas { get; set; }
        public string texto { get; set; } = "teste";
    }
}
