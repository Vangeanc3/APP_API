namespace APP_API.Models
{
    public class Produto
    {
        
        public int Id { get; set; }
        public double PrecoFinal { get; set; }
        public double PrecoInstalador { get; set; }
        public string Descricao { get; set; }
        public string LinkImg { get; set; }
        public string LinkPdfManual { get; set; }

    }
}