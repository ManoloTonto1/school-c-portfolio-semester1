using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;


namespace admin
{
    public class DemogragischRapport : Rapport
    {

        private DatabaseContext context = DatabaseContext.getInstance();

        public string Naam()
        {

            return "";
        }

        public async Task<int> Genereer()
        {

            return 0;
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

        async Task<(string, int)[]> VerdelingPerDag()
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
