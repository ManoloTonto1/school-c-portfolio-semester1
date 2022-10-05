using System.ComponentModel.DataAnnotations.Schema;
namespace admin{

    public class GastInfo{

        // relationships
        public int gastId { get; set; }
        public Gast gast { get; set; }
        public Coordinate coordinate = new Coordinate();

        // props
        public string? LaatsteBezochteUrl { get; set; }
    }
}
