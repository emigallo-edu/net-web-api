using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetWebApi.Model;
using NetWebApi.Utils;
using Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userRepository, SignInManager<User> signInManager)
        {
            this._userManager = userRepository;
            this._signInManager = signInManager;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            var result = await this._signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (result.Succeeded)
            {
                User user = await this._userManager.FindByNameAsync(dto.UserName);
                var roles = await this._userManager.GetRolesAsync(user);
                UserTokenResponse userTokenResponse = this.CreateToken(roles);

                LoginResponseDTO responseDTO = new LoginResponseDTO()
                {
                    Token = userTokenResponse.Token,
                    Expiration = userTokenResponse.Expiration
                };
                return Ok(responseDTO);
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDTO dto)
        {
            User user = dto.GetUser();
            user.PasswordHash = this._userManager.PasswordHasher.HashPassword(user, dto.PasswordHash);

            var result = await this._userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await this._userManager.AddToRolesAsync(user, dto.Roles);
                return Ok(result);
            }
            return BadRequest();
        }

        private UserTokenResponse CreateToken(IList<string> roles)
        {
            var claims = new List<Claim>
                {
                    new Claim("miValor", "Lo que yo quiera"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigureToken1.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddYears(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);
            return new UserTokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}