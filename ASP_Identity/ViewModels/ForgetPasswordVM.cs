using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Identity.ViewModels;

public class ForgetPasswordVM 
{

    [Required(ErrorMessage = "Email formati sehvdir")]
    [Display(Name = "Email: ")]
    public string Email { get; set; }


}
