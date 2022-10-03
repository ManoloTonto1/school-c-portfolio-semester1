using System.ComponentModel.DataAnnotations.Schema;
namespace admin
{
    public class Gast : Gebruiker
    {
        // relationships
        public bool isBegeleider { get; set; } = false;
        public List<Reservering> reserveringen = new List<Reservering>();

        public int attractieId { get; set; }
        public Attractie? FavoriteAttractie { get; set; }

        public int gastInfoId { get; set; }
        public GastInfo info { get; set; }

        // props
        public int Credits { get; set; }
        public DateTime GeboorteDatum { get; set; }

        public DateTime EersteBezoek { get; set; }
   

        public Gast(string email) : base(email) => base.Email = email;

    }
}
