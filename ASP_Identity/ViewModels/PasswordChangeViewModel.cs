using System.ComponentModel.DataAnnotations;

namespace ASP_Identity.ViewModels;

public class PasswordChangeViewModel
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre bos ola bilmez")]
    [Display(Name = "Yeni şifre :")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 reqem-herifli ola biler")]
    public string PasswordOld { get; set; } = null!;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Sifre bos ola bilmez")]
    [Display(Name = "Yeni şifre :")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 reqem-herifli ola biler")]
    public string PasswordNew { get; set; } = null!;

    [DataType(DataType.Password)]
    [Compare(nameof(PasswordNew), ErrorMessage = "Şifre eyni deyil")]
    [Required(ErrorMessage = "Yeni şifre tekrari bos buraxilmaz ")]
    [Display(Name = "Yeni şifre tekrari :")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 reqem-herifli ola biler")]
    public string PasswordNewConfirm { get; set; } = null!;


}
