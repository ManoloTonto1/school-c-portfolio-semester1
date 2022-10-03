using Microsoft.EntityFrameworkCore;

namespace admin{

    public class DateTimeBereik{

        // relationships
        public int Id { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? Eind { get; set; }

        public bool Eindigt(){

            Eind = new DateTime().ToLocalTime();
            return true;
        }

        public bool Overlap(DateTimeBereik that){

            return true;
        }
    }
}
