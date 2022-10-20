using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace apiApp.Controllers;

public class JWTTools{

    public string getToken(string token){
        var tokenSplit = token.Split(" ");

        if (token == null)
        {
            return "";
        }
        if (tokenSplit[0] != "Bearer")
        {
            return "";
        }
        return tokenSplit[1];
    } 
    public (bool, bool) checkTokenAndRole(string token)
    {
        var _token = getToken(token);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("MySuperSecureKey");
        tokenHandler.ValidateToken(_token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        }, out SecurityToken validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        var role = jwtToken.Claims.First(x => x.Type.Contains("role")).Value;
        return role == "admin" ? (true, true) : (true, false);
    }
    public string getUserFromToken(string token)
    {
        var _token = getToken(token);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("MySuperSecureKey");
        tokenHandler.ValidateToken(_token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        }, out SecurityToken validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        var user = jwtToken.Claims.First(x => x.Type.Contains("name")).Value;
        return user;
    }
}