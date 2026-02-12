using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ASP_Identity.Localizations;

public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DuplicateUserName(string userName)
    {

        return new()
        {
            Code = "DuplicateUserName",
            Description = $"Bu {userName} daha evvel basqa bir istifadeci terefinden alinib"
        };
        //return base.DuplicateUserName(userName);
    }

    public override IdentityError DuplicateEmail(string email)
    {
        return new()
        {
            Code = "DuplicateEmail",
            Description = $"Bu {email} daha evvel basqa bir istifadeci terefinden alinib"
        };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new()
        {
            Code = "PasswordTooShort",
            Description = $"Sifre en az 6 say olmalidir"
        };
    }


}
