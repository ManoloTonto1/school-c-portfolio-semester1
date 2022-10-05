using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace admin{


    public class Reservering{

        public Reservering(){

        }
        
        public Reservering(Attractie a, DateTimeBereik d, Gast g){
            gast = g;
            attractie = a;
            datumReserveering = d;
        }
        // relationships 
        public int Id { get; set; }

        public int gastId { get; set; }
        public Gast? gast { get; set; }
        
        public int attractieId { get; set; }
        public Attractie? attractie { get; set; }

        // props

        public DateTimeBereik datumReserveering { get; set; }
    }
}
