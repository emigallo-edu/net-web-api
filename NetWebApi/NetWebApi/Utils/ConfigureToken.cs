using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetWebApi.Utils
{
    public static class ConfigureToken1
    {
        public static string Secret { get => "jkfjsdl�jsdfgkfdnbknckdjflskdjflskd"; }

        public static void ConfigureToken(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Secret);

            //services
            //    .AddAuthentication(x =>
            //    {
            //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddJwtBearer(x =>
            //    {
            //        x.RequireHttpsMetadata = false;
            //        x.SaveToken = true;
            //        x.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            ValidateIssuer = false,
            //            ValidateAudience = false,
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });
        }
    }
}