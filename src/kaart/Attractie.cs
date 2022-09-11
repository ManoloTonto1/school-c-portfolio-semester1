namespace kaart{

    public class Attractie : KaartItem{

        private int? _minimaleLengte;
        public int? MinimaleLengte { get{
                return _minimaleLengte;
            } set{
                _minimaleLengte = value;
            } 
        }

        private int _angstLevel;

        public int AngstLevel{
            get{
                return _angstLevel;

            }
            set{
                _angstLevel = value;
            }
        }

        private string _naam;

        public string Naam {
            get{
                return _naam;
            }
            set{
                _naam = value;
            }
        }


        public Attractie(Kaart kaart, Coordinaat coordinaat) : base(kaart, coordinaat){}



    }
}