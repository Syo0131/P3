
using DataBase.Entities.Series;


namespace DataBase.Entities.Productoras
{
    public class Productora
    {
        public int IdProductora { get; set; }
        public string NombreProductora { get; set; }


        //Navigation properties
        public  ICollection<Serie> Series { get; set; }
    }
}
