using DataBase.Core;
using DataBase.Entities.Generos;
using DataBase.Entities.Productoras;





namespace DataBase.Entities.Series
{
    public class Serie 
    {
        public int IdSerie { get; set; }
        public  string Titulo { get; set; }
        public  string PortadaUrl { get; set; }
        public  string VideoURl { get; set; }
        public int IdProductora { get; set; } //FK
        public int IdGeneroPrimario { get; set; } //FK
        public int? IdGeneroSecundario { get; set; } //FK



        //Navigation properties

        public  Productora Productora { get; set; }
        public  Genero GeneroPrimario { get; set; }
        public  Genero GeneroSecundario { get; set; }
    }
}
