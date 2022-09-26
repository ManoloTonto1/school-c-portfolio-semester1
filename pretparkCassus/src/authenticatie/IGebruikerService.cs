namespace authenticatie{

    public interface IGebruikerService{
        Gebruiker Registreer(string email, string Wachtwoord);
        bool Login(string email, string password);
        bool Verifeer(string email, string token);
    }
}