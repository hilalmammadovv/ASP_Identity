using System.ComponentModel.DataAnnotations;
using ASP_Identity.Models;

namespace ASP_Identity.ViewModels;

public class UserEditViewModel
{

    [Required(ErrorMessage = "Ad bos ola bilmez")]
    [Display(Name = "Istifadeci Adi: ")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email formati sehvdir")]
    [Display(Name = "Email: ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Telefon nomresi bos ola bilmez")]
    [Display(Name = "Telefon: ")]
    public string Phone { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Doğum tarixi :")]
    public DateTime? BirthDate { get; set; }

    [Display(Name = "Seher :")]
    public string? City { get; set; }

    [Display(Name = "Profil resmi :")]
    public IFormFile? Picture { get; set; }

 

    [Display(Name = "Cinsiyyet: ")]
    public Gender Gender { get; set; }


}
