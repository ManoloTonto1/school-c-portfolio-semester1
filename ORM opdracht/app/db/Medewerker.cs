using System.ComponentModel.DataAnnotations.Schema;
namespace admin
{
    public class Medewerker : Gebruiker
    {
        // relationships
        public List<OnderHoud> onderhoudenTeDoen  = new List<OnderHoud>();
        public List<OnderHoud> onderhoudenTeCoordineren = new List<OnderHoud>();

        // props
        public Medewerker(string email) : base(email) => base.Email = email;

    }
}
