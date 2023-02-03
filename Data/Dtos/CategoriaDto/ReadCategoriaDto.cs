using APP_API.Data.Dtos.LinhaDto;
using APP_API.Models;

namespace APP_API.Data.Dtos.CategoriaDto
{
    public class ReadCategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Linhas { get; set; }
    }
}
