using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Pubquizish.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("test");
        }

        [HttpGet("{provider}")]
        public IActionResult ExternalSignIn([FromRoute] string provider, [FromQuery] string returnUrl)
        {
            return new ChallengeResult(
                provider,
                _signInManager.ConfigureExternalAuthenticationProperties(
                    provider,
                    Url.Action(nameof(SignedIn), new { returnUrl })
                )
            );
        }

        [HttpGet]
        public async Task<IActionResult> SignedIn([FromQuery] string returnUrl)
        {
            ExternalLoginInfo externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();

            Microsoft.AspNetCore.Identity.SignInResult signinResult = await _signInManager.ExternalLoginSignInAsync(
                externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true
            );

            if (signinResult.Succeeded)
            {
                return new RedirectResult(returnUrl);
            }

            string email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            var identityUser = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            IdentityResult identityResult = await _userManager.CreateAsync(identityUser);

            if (!identityResult.Succeeded)
            {
                return new RedirectResult($"{returnUrl}?error={identityResult.Errors?.ToString()}");
            }

            identityResult = await _userManager.AddLoginAsync(identityUser, externalLoginInfo);

            if (!identityResult.Succeeded)
            {
                return new RedirectResult($"{returnUrl}?error={identityResult.Errors?.ToString()}");
            }

            if (!await _roleManager.RoleExistsAsync("Gamehost"))
            {
                var role = new IdentityRole("Gamehost");
                await _roleManager.CreateAsync(role);
            }

            await _userManager.AddToRoleAsync(identityUser, "Gamehost");

            await _userManager.AddClaimAsync(identityUser, new Claim(ClaimTypes.NameIdentifier, identityUser.Id));

            await _signInManager.SignInAsync(identityUser, false, externalLoginInfo.LoginProvider);

            return new RedirectResult(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> SignOut([FromQuery] string returnUrl)
        {
            await _signInManager.SignOutAsync();

            return new RedirectResult(returnUrl);
        }
    }
}
