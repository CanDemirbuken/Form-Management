using Microsoft.AspNetCore.Identity;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.ServiceContracts
{
    public interface IUsersService
    {
        Task<IdentityResult> RegisterAsync(ApplicationUser user, string password);
        Task<SignInResult> LoginAsync(string username, string password, bool rememberMe);
        Task LogoutAsync();
    }
}
