using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace apiApp.Controllers;

public class JWTTools{
    public (bool, bool) checkTokenAndRole(string token)
    {
        var tokenSplit = token.Split(" ");

        if (token == null)
        {
            return (false, false);
        }
        if (tokenSplit[0] != "Bearer")
        {
            return (false, false);
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("MySuperSecureKey");
        tokenHandler.ValidateToken(tokenSplit[1], new TokenValidationParameters
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
}