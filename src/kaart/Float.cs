using System.Globalization;

namespace kaart{

    public static class Float{

        public static string metSuffixen( this float value){
            // Displays 1,234,568K
            return value.ToString("#,##0,K", CultureInfo.InvariantCulture);
        }
    }
}