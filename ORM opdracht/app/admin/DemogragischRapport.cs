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

        }

        async Task<Gast?> GastBijEmail(string email){

        }

        async Task<Gast> GastBijGeboorteDatum(DateTime datetime){

        }

        async Task<int> PercentageBejaarden(){

        }

        async Task<int> HoogsteBejaarden(){

        }

        async Task<IEnumerable<Gast>> Blut(IEnumerable<Gast> gast){

        } 

        async Task<(string,int)[]> VerdelingPerDag(){

        }

        async Task<List<(Gast,int)>> GastenMetActiviteit(IEnumerable<Gast> gast){

        }

        async Task<int> FavorietCorrect(){
            
        }
    }
}
