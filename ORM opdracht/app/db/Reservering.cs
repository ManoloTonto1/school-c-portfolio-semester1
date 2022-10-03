using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace admin{


    public class Reservering{
        // relationships 
        public int Id { get; set; }

        public int gastId { get; set; }
        public Gast? gast { get; set; }
        
        public int attractieId { get; set; }
        public Attractie? attracties { get; set; }

        // props

        public DateTimeBereik datumReserveering { get; set; }
    }
}
