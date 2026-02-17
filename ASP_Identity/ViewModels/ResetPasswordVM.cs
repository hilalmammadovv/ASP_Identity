using System.ComponentModel.DataAnnotations;

namespace ASP_Identity.ViewModels;

public class ResetPasswordVM
{

    [Required(ErrorMessage = "Sifre bos ola bilmez")]
    [Display(Name = "Sifre: ")]
    public string Password { get; set; }



    [Compare(nameof(Password), ErrorMessage = "Sifre eyni deyil")]
    [Required(ErrorMessage = "Sifre tekrari bos ola bilmez")]
    [Display(Name = "Sifre Tekrari: ")]
    public string PasswordConfirm { get; set; }
}
