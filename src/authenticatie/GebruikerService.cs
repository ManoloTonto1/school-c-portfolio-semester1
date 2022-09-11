namespace authenticatie
{

    class GebruikerService
    {

        public Gebruiker Registreer(string email, string Wachtwoord)
        {
            if (GebruikerContext.gebruikers.Exists(x => x.Email == email )){
                System.Console.WriteLine("user already exists");
                return null;
            }
            Gebruiker gebruiker = new Gebruiker(email, Wachtwoord);

            gebruiker.token = new VerificatieToken();

            EmailService emailService = new EmailService();

            var success = emailService.Email(gebruiker.token.token, gebruiker.Email);

            if (!success){
                System.Console.WriteLine("failed to create user");
            }
            System.Console.WriteLine("Account created!");
            return gebruiker;
        }

        public bool Login(string email, string password)
        {
            if (GebruikerContext.gebruikers.Exists(x => x.Email == email && x.Wachtwoord == password))
            {
                System.Console.WriteLine("Logged in!");
                return true;
            }
            System.Console.WriteLine("Error while logging in");
            return false;
        }

        public bool Verifeer(string email, string token)
        {

            if (GebruikerContext.gebruikers.Exists(x => x.Email == email && x.token.token == token))
            {
                System.Console.WriteLine("Account Verified!");
                return true;
            }
            System.Console.WriteLine("Verification failed, check if details are correct");
            return false;
        }

    }
}