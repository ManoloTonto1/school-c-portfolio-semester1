using Microsoft.EntityFrameworkCore;

namespace admin {

    [Owned]
    public class Coordinate{

        public int X { get; set; }
        public int Y { get; set; }
    }
}
