
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace admin
{
    public class OnderHoud
    {
        // relationships
        public int Id { get; set; }

        public List<Medewerker> coordinatoren = new List<Medewerker>();

        public List<Medewerker> medewerkers = new List<Medewerker>();

        public int attractieId { get; set; }
        public Attractie attractieOmTeOnderhouden { get; set; }

        public DateTimeBereik datumonderhoud = new DateTimeBereik();

        // props
        public string Probleem { get; set; }
    }
}
