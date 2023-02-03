using APP_API.Models;

namespace APP_API.Data.Dtos.LinhaDto
{
    public class ReadLinhaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Produtos { get; set; }
    }
}
