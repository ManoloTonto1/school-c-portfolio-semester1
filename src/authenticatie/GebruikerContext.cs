

namespace authenticatie{

    public class GebruikerContext{
        private static GebruikerContext? Instance = null;

        private GebruikerContext() { }

        public static GebruikerContext GetInstance(){
            if (Instance is null){
                Instance = new GebruikerContext();
            };
            return Instance;
        }
        public List<Gebruiker> gebruikers = new List<Gebruiker>();

        public int AantalGebruikers() => gebruikers.Count;
        public Gebruiker GetGebruiker(int i) => gebruikers[i];

        public void NewGebruiker(Gebruiker geb) => gebruikers.Add(geb);

    }
}