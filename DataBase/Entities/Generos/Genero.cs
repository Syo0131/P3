
using DataBase.Entities.Series;


namespace DataBase.Entities.Generos
{
    public class Genero 
    {
        public int IdGenero { get; set; }
        public string NombreGenero { get; set; }


        //Navigation properties        
        public ICollection<Serie> Series { get; set; }

    }
}
