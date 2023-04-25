using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.UI.Controllers
{
    [Authorize]
    public class LogoutController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutController> _logger;

        public LogoutController(SignInManager<ApplicationUser> signInManager, ILogger<LogoutController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetLogout()
        {
            return RedirectToAction(nameof(LoginController.Index), "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
