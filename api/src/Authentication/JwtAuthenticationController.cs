using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Pubquizish.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JwtAuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public JwtAuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpGet("{provider}")]
        public IActionResult External([FromRoute] string provider, [FromQuery] string returnUrl)
        {
            return new ChallengeResult(
                provider,
                new AuthenticationProperties { RedirectUri = Url.Action(nameof(SignedIn), new { returnUrl }) }
            );
        }

        [HttpGet]
        public async Task<IActionResult> SignedIn([FromQuery] string returnUrl)
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);

            if (!authenticateResult.Succeeded)
            {
                return new RedirectResult(returnUrl + $"?error={authenticateResult.Failure?.ToString()}");
            }

            var userEmail = authenticateResult.Principal.FindFirstValue(ClaimTypes.Email);

            var IdentityUser = await userManager.FindByEmailAsync(userEmail);

            if (IdentityUser == null)
            {
                IdentityUser = new IdentityUser
                {
                    Email = userEmail,
                    UserName = userEmail,
                };

                var identityResult = await userManager.CreateAsync(IdentityUser);

                if (!identityResult.Succeeded)
                {
                    return new RedirectResult(returnUrl + $"?error={identityResult.Errors?.ToString()}");
                }
            }

            var jwtSecuritytokenHandler = new JwtSecurityTokenHandler();

            var secret = Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]);

            var token = jwtSecuritytokenHandler.CreateToken(
                new SecurityTokenDescriptor
                {
                    Audience = configuration["Jwt:Audience"],
                    Issuer = configuration["Jwt:Issuer"],
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Sid, IdentityUser.Id.ToString()),
                        new Claim(ClaimTypes.Role, "Gamehost")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:ExpirationMinutes"])),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
                }
            );

            return new RedirectResult(returnUrl + $"?token={jwtSecuritytokenHandler.WriteToken(token)}");
        }
    }
}
