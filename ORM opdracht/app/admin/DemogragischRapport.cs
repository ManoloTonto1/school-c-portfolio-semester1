using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;


namespace admin
{

    public class DemogragischRapport : Rapport{

        public string Naam(){

            return "";
        }

        public async Task<int> Genereer(){

            return 0;
        }

        async Task<int> AantalGebruikers(){

            return 0;
        }

        async Task<bool> AlleGastenHebbenReservering(){

            return true;
        }

        async Task<int> AantalSinds(DateTime date, bool uniek){
            return 0;

        }

        async Task<Gast?> GastBijEmail(string email){

            return new Gast("");

        }

        async Task<Gast> GastBijGeboorteDatum(DateTime datetime){
return new Gast("");
        }

        async Task<int> PercentageBejaarden(){
return 0;
        }

        async Task<int> HoogsteBejaarden(){
return 0;
        }

        async Task<IEnumerable<Gast>> Blut(IEnumerable<Gast> gast){
            return gast;

        } 

        async Task<(string,int)[]> VerdelingPerDag(){

            (string, int)[] bitch = { };
            return bitch;

        }

        async Task<List<(Gast,int)>> GastenMetActiviteit(IEnumerable<Gast> gast){
            return new List<(Gast, int)>();
        }

        async Task<int> FavorietCorrect(){
            return 0;
            
        }
    }
}
