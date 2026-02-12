using System.ComponentModel.DataAnnotations;

namespace ASP_Identity.ViewModels;

public class SignInVM
{

    public SignInVM()
    {

    }

    public SignInVM(string email, string password)
    {
        Email = email;
        Password = password;
    }

    [Required(ErrorMessage = "Email formati sehvdir")]
    [Display(Name = "Email: ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Sifre bos ola bilmez")]
    [Display(Name = "Sifre: ")]
    public string Password { get; set; }

    [Display(Name = "Meni xatirla ")]
    public bool RememberMe { get; set; }

}
