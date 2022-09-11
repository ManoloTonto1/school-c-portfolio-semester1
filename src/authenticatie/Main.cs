namespace authenticatie
{

    class main
    {

        private static Gebruiker currentUser;
        static GebruikerService service = new GebruikerService();

        public static void Main(string[] args)
        {
            

            Console.WriteLine("1. Login ");
            Console.WriteLine("2. Register ");

            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    System.Console.WriteLine("your email:");
                    var email = Console.ReadLine();

                    System.Console.WriteLine("your password:");
                    var password = Console.ReadLine();

                    var success = service.Login(email, password);

                    if (success) System.Console.WriteLine("successfully logged in!");

                    if (!success)
                    {
                        System.Console.WriteLine("not logged in try again");
                        goto case 1;
                    }
                    break;

                case 2:
                    System.Console.WriteLine("your email:");
                    var emailReg = Console.ReadLine();

                    System.Console.WriteLine("your password:");
                    var passwordReg = Console.ReadLine();

                    currentUser = service.Registreer(emailReg, passwordReg);
                    System.Console.WriteLine("successfully Created Account now verify it!");

                    VerifyToken:
                    System.Console.WriteLine("insert token to verify: ");
                    var tokenInput = Console.ReadLine();

                    var tokenSuccess = service.Verifeer(currentUser.Email, tokenInput);

                    if (tokenSuccess) System.Console.WriteLine("user verified");

                    if (!tokenSuccess)
                    {
                        System.Console.WriteLine("error when verifying");
                        goto VerifyToken;
                    }
                    break;


            }

        }
    }
}