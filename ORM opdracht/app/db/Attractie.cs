using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace admin
{

    public class Attractie
    {
        public Attractie(string n){
            Naam = n;
        }
        public Attractie(){}
        // relationships
        public int Id { get; set; }
        public List<Reservering> reserveringen { get; set; }
        public List<Gast> gastenFav { get; set; }

        public List<OnderHoud> onderHouden { get; set; }

        // props
        public string Naam { get; set; }

        public async Task<bool> OnderhoudBezig(DatabaseContext context)
        {
            var now = new DateTime().Date;
            var q = await Task.Run(() => context.OnderHouden.Where(o => o.datumonderhoud.Eind < now).Count());

            if (q > 0) return true;
            return false;


        }
        public async Task<bool> Vrij(DatabaseContext context, DateTimeBereik bereik)
        {

            var q = await Task.Run(() => context.Reserveringen.Single(r => r.datumReserveering == bereik));

            if(q == null) return true;
            return false;
        }
    }
}
