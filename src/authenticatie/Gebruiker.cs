using System;

namespace authenticatie
{
    public class Gebruiker
    {
        public string Wachtwoord { get; set; }
        public string Email { get; set; }

        public VerificatieToken? token;

        public Gebruiker(string email, string password)
        {
            Email = email;
            this.Wachtwoord = password;
        }

        public bool Geverifeerd()
        {
            if (token.token is null)
                return false;
            if (token.verloopDatum >= DateTime.Today)
                return false;
            return true;
        }
    }
}