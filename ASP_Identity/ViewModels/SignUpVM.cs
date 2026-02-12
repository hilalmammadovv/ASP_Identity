using System.ComponentModel.DataAnnotations;

namespace ASP_Identity.ViewModels;

public class SignUpVM
{
    public SignUpVM() { }
    

    public SignUpVM(string userName, string email, string phone, string password)
    {
        UserName = userName;
        Email = email;
        Phone = phone;
        Password = password;
    }


    [Required(ErrorMessage ="Ad bos ola bilmez")]
    [Display(Name = "Istifadeci Adi: ")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email formati sehvdir")]
    [Display(Name = "Email: ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Telefon nomresi bos ola bilmez")]
    [Display(Name = "Telefon: ")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Sifre bos ola bilmez")]
    [Display(Name = "Sifre: ")]
    public string Password { get; set; }



    [Compare(nameof(Password), ErrorMessage ="Sifre eyni deyil")]
    [Required(ErrorMessage = "Sifre tekrari bos ola bilmez")]
    [Display(Name = "Sifre Tekrari: ")]
    public string PasswordConfirm { get; set; }


}
