using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FuelAccounting.Services
{
    public class Authorization
    {
        public const string ISSUER = "https://localhost:5555/";
        public const string AUDIENCE = "https://localhost:5555/";
        const string KEY = "UnsereWeltUntergang1488202455WhitePower";
        public const int LIFETIME = 500;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
