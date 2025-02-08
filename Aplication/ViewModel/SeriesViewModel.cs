using DataBase.Entities.Generos;
using DataBase.Entities.Productoras;

namespace Aplication.ViewModel
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string PortadaUrl { get; set; }
        public string VideoURl { get; set; }
        public int IdProductora { get; set; }
        public string NombreProductora { get; set; }
        public int IdGeneroPrimario { get; set; }
        public string NombreGeneroPrimario { get; set; }
        public int? IdGeneroSecundario { get; set; }
        public string NombreGeneroSecundario { get; set; }
    }
}
