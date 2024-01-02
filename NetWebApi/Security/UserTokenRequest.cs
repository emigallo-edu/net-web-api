using System.Security.Claims;

namespace Security
{
    public class UserTokenRequest
    {
        public ClaimsIdentity? Email { get; set; }
    }

    public class UserTokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}