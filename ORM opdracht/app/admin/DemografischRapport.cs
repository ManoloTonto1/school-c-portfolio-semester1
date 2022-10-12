namespace admin
{

    public class DemografischRapport : Rapport
    {

        private DatabaseContext context = new DatabaseContext();

        public DemografischRapport(DatabaseContext context) => this.context = context;

        public override string Naam() => "Demografie";

        public async override Task<string> Genereer()
        {
            context.ChangeTracker.LazyLoadingEnabled = false;

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

            if (uniek)
            {

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

            if (result != null) return result;

            throw new Exception("Does not exist, or not found");
        }

        async Task<int> PercentageBejaarden()
        {
            var _80YearsAgo = DateTime.Now.Year - 80;
            var result80s = await Task.Run(() => context.Gasten.Where(g => g.GeboorteDatum.Year <= _80YearsAgo).Count());
            var resultAll = await Task.Run(() => context.Gasten.Count());

            var total = result80s * 100 / resultAll;
            return total;
        }

        async Task<int> HoogsteLeeftijd()
        {
            return await Task.Run(() =>
            {
                var date = context.Gasten.Min(g => g.GeboorteDatum);
                return DateTime.Now.Year - date.Year;
            });
        }

        async Task<IEnumerable<Gast>> Blut(IEnumerable<Gast> gasten)
        {
            return await Task.Run(() => gasten.Where(g => g.Credits != 0));
        }

        async Task<(string dag, int aantal)[]> VerdelingPerDag()
        {
            var list = await Task.Run(() =>
            {
                List<(string, int)> listOfDates = new List<(string, int)>();
                var countPerDay = context.Gasten.Select(g => g.EersteBezoek).ToList();
                for (int i = 1; i < 7; i++)
                {
                    var day = countPerDay.FindAll(d => (int)d.DayOfWeek == i);
                    if (day == null)
                    {
                        continue;
                    }
                    var currentDatetime = day.FirstOrDefault();
                    var currentDay = currentDatetime.DayOfWeek.ToString();
                    var tup = Tuple.Create(currentDay, day.Count);
                    listOfDates.Add((tup.Item1, tup.Item2));
                }
                return listOfDates.ToArray();
            });


            return list;

        }

        async Task<List<(Gast, int)>> GastenMetActiviteit(IEnumerable<Gast> gast)
        {
            return new List<(Gast, int)>();
        }

        async Task<int> FavorietCorrect()
        {
            return await Task.Run(() =>
            {
                var countOfPeople = context.Gasten.Where(
                gast =>
                    (context.Reserveringen.Where(res => res.attractie == gast.FavoriteAttractie).Count()) > (context.Reserveringen.Where(ress => ress.gast == gast).Count())
                ).Count();

                return countOfPeople;
            });



        }

    }
}
