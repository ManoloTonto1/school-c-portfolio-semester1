using System.ComponentModel.DataAnnotations.Schema;
namespace admin
{
    public class Gast : Gebruiker
    {
        // relationships
        public bool isBegeleider { get; set; } = false;
        public List<Reservering> reserveringen { get; set; }

        public int FavAttractieID { get; set; }
        public Attractie? FavoriteAttractie { get; set; }

        public int gastInfoID { get; set; }
        public GastInfo info { get; set; }

        // props
        public int Credits { get; set; }
        public DateTime GeboorteDatum { get; set; }

        public DateTime EersteBezoek { get; set; }
   

        public Gast(string email) : base(email) => base.Email = email;

    }
}
