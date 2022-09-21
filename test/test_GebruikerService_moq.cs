using Moq;
using Xunit;

namespace authenticatie.test;

public class test_GebruikerService_moq
{
    [Theory]
    [InlineData("email","pass")]
    [InlineData("emailExample","sexy")]
    public void Registreer_test_moq(string a, string b)
    {
        // Arrange
        var mock = new Mock<IGebruikerService>();
        mock.Setup(lib => lib.Registreer(a,b)).Returns(new Gebruiker(a, b));
        var obj = mock.Object;

        //act 
        Gebruiker user = obj.Registreer(a, b);

        //assert
        Xunit.Assert.Equal(a, user.Email);
        mock.Verify(lib => lib.Registreer(a, b), Times.AtMostOnce());

    }
    [Theory]
    [InlineData("email","pass")]
    [InlineData("emailExample","sexy")]
    public void Login_test_returnsTrue_moq(string a, string b)
    {
        // Arrange
        var mock = new Mock<IGebruikerService>();
        mock.Setup(lib => lib.Login(a,b)).Returns(true);
        var obj = mock.Object;

        //act
        var boolean = obj.Login(a, b);

        //assert
        Xunit.Assert.True(boolean);
        mock.Verify(lib => lib.Login(a, b), Times.AtMostOnce());

    }
    [Theory]
    [InlineData("email","pass")]
    [InlineData("emailExample","sexy")]
    public void Login_test_returnsFalse_moq(string a, string b)
    {
        // Arrange
        var mock = new Mock<IGebruikerService>();
        mock.Setup(lib => lib.Login(a,b)).Returns(false);
        var obj = mock.Object;

        //act
        var boolean = obj.Login(a, b);

        //assert
        Xunit.Assert.True(boolean);
        mock.Verify(lib => lib.Login(a, b), Times.AtMostOnce());

    }

    [Theory]
    [InlineData("email","token")]
    [InlineData("emailExample","sexy")]
    public void Verifeer_test_moq(string a, string b)
    {
        // Arrange
        var mock = new Mock<IGebruikerService>();
        mock.Setup(lib => lib.Verifeer(a,b)).Returns(true);
        var obj = mock.Object;

        //act
        var boolean = obj.Verifeer(a, b);

        //assert
        Xunit.Assert.True(boolean);
        mock.Verify(lib => lib.Verifeer(a, b), Times.AtMostOnce());

    }
    [Theory]
    [InlineData("email","token")]
    [InlineData("emailExample","sexy")]
    public void Verifeer_test_returns_false_moq(string a, string b)
    {
        // Arrange
        var mock = new Mock<IGebruikerService>();
        mock.Setup(lib => lib.Verifeer(a,b)).Returns(false);
        var obj = mock.Object;

        //act
        var boolean = obj.Verifeer(a, b);

        //assert
        Xunit.Assert.False(boolean);
        mock.Verify(lib => lib.Verifeer(a, b), Times.AtMostOnce());

    }
}