
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace admin
{
    public class OnderHoud
    {
        // relationships
        public int Id { get; set; }

        public List<Medewerker> coordinatoren { get; set; }

        public List<Medewerker> medewerkers { get; set; }

        public int attractieId { get; set; }
        public Attractie attractieOmTeOnderhouden { get; set; }

        public DateTimeBereik datumonderhoud = new DateTimeBereik();

        // props
        public string Probleem { get; set; }
    }
}
