using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace admin
{

    public class Attractie
    {
        // relationships
        public int Id { get; set; }
        public List<Reservering> reserveringen = new List<Reservering>();
        public List<Gast> gastenFav = new List<Gast>();

        public List<OnderHoud> onderHouden = new List<OnderHoud>();

        // props
        public string Naam { get; set; }

        public async Task<bool> OnderhoudBezig(DatabaseContext context)
        {

            return true;
        }
        public async Task<bool> Vrij(DatabaseContext context, DateTimeBereik bereik)
        {

            return true;
        }
    }
}
