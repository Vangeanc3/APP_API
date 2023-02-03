using APP_API.Interfaces;

namespace APP_API.Services
{
    public class GerarIdentificadorService : IGerarIdentificadorService
    {

        public string GerarIdentificador()
        {
            var random = new Random();
            int ano = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int numeroRandom = random.Next(1000, 9999);
            
             return $"{ano}{mes:D2}{numeroRandom:D4}";
        }
    }
}
