using FuelAccounting.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FuelAccounting.API.Infrastructures
{
    public static class AddAuthorizationExtensions
    {
        public static void GetAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Authorization.ISSUER,
                     ValidAudience = Authorization.AUDIENCE,
                     IssuerSigningKey = Authorization.GetSymmetricSecurityKey(),
                 };
             });
        }
    }
}
