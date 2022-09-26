
using System.Collections.Generic;

namespace kaart
{
    public class Kaart
    {
        public int Breedte { get; set; }
        public int Hoogte { get; set; }

        public Kaart(int Breedte, int Hoogte){
            this.Breedte = Breedte;
            this.Hoogte = Hoogte;
        }
        public List<Pad> Padden = new List<Pad>();
        public List<KaartItem> KaartItems = new List<KaartItem>();

        public void Teken(ITekener t){
           foreach(Pad pad in Padden){
                t.Teken(pad);
            }

        }

        public void VoegPadToe(Pad pad){

            Padden.Add(pad);
        }
        public void VoegItemToe(KaartItem item){

            KaartItems.Add(item);
        }


    }
}