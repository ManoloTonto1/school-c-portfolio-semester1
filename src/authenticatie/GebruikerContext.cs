using System.Collections.Generic;

namespace authenticatie{

    public class GebruikerContext{
        public static List<Gebruiker> gebruikers = new List<Gebruiker>();

        public int AantalGebruikers() => gebruikers.Count;
        public Gebruiker GetGebruiker(int i) => gebruikers[i];

        public void NewGebruiker(string email, string password) => gebruikers.Add(new Gebruiker(email, password));

    }
}