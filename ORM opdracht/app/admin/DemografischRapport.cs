namespace admin
{
    public class DemografischRapport : Rapport
    {

        private DatabaseContext context = new DatabaseContext();

        public DemografischRapport(DatabaseContext context) => this.context = context;

        public override string Naam() => "Demografie";

        public async override Task<string> Genereer()
        {
            string ret = "Dit is een demografisch rapport: \n";
            ret += $"Er zijn in totaal {await AantalGebruikers()} gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
            var dateTime = new DateTime(2000, 1, 1);
            ret += $"Er zijn {await AantalSinds(dateTime)} bezoekers sinds {dateTime}\n";
            if (await AlleGastenHebbenReservering())
                ret += "Alle gasten hebben een reservering\n";
            else
                ret += "Niet alle gasten hebben een reservering\n";
            ret += $"Het percentage bejaarden is {await PercentageBejaarden()}\n";

            ret += $"De oudste gast heeft een leeftijd van {await HoogsteLeeftijd()} \n";

            ret += "De verdeling van de gasten per dag is als volgt: \n";
            var dagAantallen = await VerdelingPerDag();
            var totaal = dagAantallen.Select(t => t.aantal).Max();
            foreach (var dagAantal in dagAantallen)
                ret += $"{dagAantal.dag}: {new string('#', (int)(dagAantal.aantal / (double)totaal * 20))}\n";

            ret += $"{await FavorietCorrect()} gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

            return ret;
        }

        async Task<int> AantalGebruikers()
        {
            var result = await Task.Run(() => context.Gebruikers.Count<Gebruiker>());

            return result;
        }

        async Task<bool> AlleGastenHebbenReservering()
        {
            var result = await Task.Run(() => context.Gasten.All<Gast>(g => g.reserveringen != null));
            return result;
        }

        async Task<int> AantalSinds(DateTime date, bool uniek = false)
        {

            if(uniek){

                return await Task.Run(() => context.Gasten.Where(g => g.EersteBezoek >= date).Select(g => g.EersteBezoek).Distinct().Count());
            }

            return await Task.Run(() => context.Gasten.Where<Gast>(g => g.EersteBezoek >= date).Count<Gast>());

        }

        async Task<Gast?> GastBijEmail(string email)
        {
            return await Task.Run(() => context.Gasten.Where(g => g.Email == email).FirstOrDefault());
        }

        async Task<Gast> GastBijGeboorteDatum(DateTime datetime)
        {
            var result = await Task.Run(() => context.Gasten.Where(g => g.GeboorteDatum == datetime).FirstOrDefault());

            if(result != null) return result;

            throw new Exception("Does not exist, or not found"); 
        }

        async Task<int> PercentageBejaarden()
        {
            var _80YearsAgo = new DateTime().Year - 80;
            var result80s = await Task.Run(() => context.Gasten.Where(g => g.GeboorteDatum.Year <= _80YearsAgo).Count());
            var resultAll = await Task.Run(() => context.Gasten.Count());

            var total = result80s * 100 / resultAll;
            return total;
        }

        async Task<DateTime> HoogsteLeeftijd()
        {
            return await Task.Run(() => context.Gasten.Max(g => g.GeboorteDatum));
        }

        async Task<IEnumerable<Gast>> Blut(IEnumerable<Gast> gasten)
        {
            return await Task.Run(() => gasten.Where(g => g.Credits != 0));
        }

        async Task<(string dag, int aantal)[]> VerdelingPerDag()
        {

            (string, int)[] bitch = { };
            return bitch;

        }

        async Task<List<(Gast, int)>> GastenMetActiviteit(IEnumerable<Gast> gast)
        {
            return new List<(Gast, int)>();
        }

        async Task<int> FavorietCorrect()
        {
            return 0;

        }

    }
}
