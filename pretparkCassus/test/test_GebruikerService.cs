using Xunit;

namespace authenticatie.test 
{

    public class test_GebruikerService
    {
        GebruikerContext context;
        EmailService emailService;
        GebruikerService service;

        public test_GebruikerService()
        {
            context = GebruikerContext.GetInstance();
            emailService = new EmailService();
            service = new GebruikerService();

        }

        [Fact]
        public void Registreer_test()
        {
            // Arrange
            var expected = new Gebruiker("email", "pass");

            //act
            var result = service.Registreer("email", "pass", emailService, context);

            //assert
            Xunit.Assert.NotNull(result.token);
        }

        [Fact]
        public void Login_test_Failed()
        {
            var a = "someOtherEmail";
            var b = "pass";

            //act
            var result = service.Login(a, b, context);

            //assert
            Xunit.Assert.False(result);

        }
        [Fact]
        public void Login_test_success()
        {
            var a = "someEmail";
            var b = "pass";
            service.Registreer(a, b, emailService, context);

            //act
            var result = service.Login(a, b, context);

            //assert
            Xunit.Assert.True(result);


        }
        [Fact]
        public void test_verifeer_Success()
        {
            // Arrange
            var a = "emailtje";
            var gebruiker = service.Registreer(a, "pass", emailService, context);
            var token = gebruiker.token.token;

            //act
            var result = service.Verifeer(a, token, context);

            //assert
            Xunit.Assert.True(result);
        }
        [Fact]
        public void test_verifeer_Failed()
        {
            // Arrange
            var a = "email";
            string token = "Random Token";

            //act
            var result = service.Verifeer(a, token, context);

            //assert 
            Xunit.Assert.False(result);
        }


    }
}