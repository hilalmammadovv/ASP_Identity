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

    [Display(Name = "Istifadeci Adi: ")]
    public string UserName { get; set; }

    [Display(Name = "Email: ")]
    public string Email { get; set; }

    [Display(Name = "Telefon: ")]
    public string Phone { get; set; }

    [Display(Name = "Sifre: ")]
    public string Password { get; set; }

    [Display(Name = "Sifre Tekrari: ")]
    public string PasswordConfirm { get; set; }


}
