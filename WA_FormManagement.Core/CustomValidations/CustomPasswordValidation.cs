using Microsoft.AspNetCore.Identity;
using WA_FormManagement.Core.Domain.Entities;

namespace WA_FormManagement.Core.CustomValidations
{
    public class CustomPasswordValidation : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser applicationUser, string? password)
        {
            List<IdentityError> errorList = new List<IdentityError>();

            if (password.Length < 8)
            {
                errorList.Add(new IdentityError
                {
                    Code = "PasswordLength",
                    Description = "Lütfen Şifreyi En az 8 Karakter Girin."
                });
            }

            if (password.ToLower().Contains(applicationUser.UserName.ToLower())) 
            {
                errorList.Add(new IdentityError
                {
                    Code = "PasswordContainerUserName",
                    Description = "Lütfen Şifre İçerisinde Kullanıcı Adını Kullanmayınız.."
                });
            }

            if (!errorList.Any())
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errorList.ToArray()));
            }
        }
    }
}
