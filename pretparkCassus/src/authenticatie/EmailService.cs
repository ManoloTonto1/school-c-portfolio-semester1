namespace authenticatie
{
    public class EmailService
    {
        public bool Email(string text,string naarAdres){

            if(text is null || naarAdres is null) return false;

            System.Console.WriteLine("sending mail to: "+ naarAdres);
            System.Console.WriteLine("your verification Token is: "+text);
            return true;
        }
    }
}