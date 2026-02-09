using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SystemWebApi.Auth;

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; 
    public const string AUDIENCE = "MyAuthClient";
    const string KEY = "mysupersecret_secretsecretsecretkey!123"; 
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}