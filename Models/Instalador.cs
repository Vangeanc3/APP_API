using APP_API.Models;

namespace APP_API.Models
{
    public class Instalador : Usuario
    {
        public List<Orcamento> Orcamentos { get; set; }
        public List<Cliente> Clientes { get; set; }
        
    }
}