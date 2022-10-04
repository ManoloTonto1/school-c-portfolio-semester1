using System.ComponentModel.DataAnnotations.Schema;
namespace admin
{
    public class Medewerker : Gebruiker
    {
        // relationships
        public List<OnderHoud> onderhoudenTeDoen { get; set; }
        public List<OnderHoud> onderhoudenTeCoordineren { get; set; }

        // props
        public Medewerker(string email) : base(email) => base.Email = email;

    }
}
