using System;

namespace authenticatie{

    public class Gast: Gebruiker{

        public int Rating { get; set; }
        public int Boete { get; set; }
        public DateTime GeboorteDatum { get; set; }

        public Gast(string email, string password) : base(email, password) { }

        public void Bezoek(){
            
        }

        public void VIPBezoek(){

        }

        public void GeefStraf(string daden){

        }
    }
}
