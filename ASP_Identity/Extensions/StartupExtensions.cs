using ASP_Identity.CustomValidations;
using ASP_Identity.Localizations;
using ASP_Identity.Models;

namespace ASP_Identity.Extensions;

public static class StartupExtensions
{
    public static void AddIdentityWithExt(this IServiceCollection services )
    {
     services.AddIdentity<AppUser, AppRole>(
  options =>
  {

      options.User.RequireUniqueEmail = true;
      options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890_";

      options.Password.RequiredLength = 6;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireLowercase = true;
      options.Password.RequireUppercase = false;
      options.Password.RequireDigit = false;





  }).AddPasswordValidator<PasswordValidator>().AddUserValidator<UserValidator>().AddErrorDescriber<LocalizationIdentityErrorDescriber>().AddEntityFrameworkStores<AppDbContext>();
    }


}
