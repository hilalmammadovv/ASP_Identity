using ASP_Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP_Identity.CustomValidations;

public class PasswordValidator : IPasswordValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
    {

        var errors = new List<IdentityError>();

        if (password!.ToLower().Contains(user.UserName!.ToLower()))
        {

            errors.Add(new()
            {
                Code = "PassowrdContainUserName",
                Description = "Sifrede ad olmaz"
            });
        }


        if (password!.ToLower().StartsWith("1234"))
        {

            errors.Add(new()
            {
                Code = "PassowrdNoContainUser1234",
                Description = "Sifrede ard arda reqem olmaz"
            });
        }

        if (errors.Any())
        {
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        return Task.FromResult(IdentityResult.Success);
    }
}
