using System;

namespace kaart
{
    public class KaartItem : ITekenbaar
    {
        private Coordinaat _locatie;


        public Char karakter { get; }

        public Coordinaat Locatie
        {
            get
            {
                return _locatie;
            }
            set
            {
                if (value.x >= 0 && value.y >= 0)
                {
                    _locatie = value;
                    return;
                }
                throw new Exception("coordinates are supposed to be positive, this was your input: x " + value.x + ", y: " + value.y);
            }
        }

        public KaartItem(Kaart kaart, Coordinaat locatie)
        {
            if (locatie.x > kaart.Breedte && locatie.y > kaart.Hoogte)
            {
                throw new Exception("out of boundries");

            }

            this.Locatie = locatie;

        }


        public void TekenConsole(ConsoleTekener t)
        {
            t.Teken(this);
        }
    }
}