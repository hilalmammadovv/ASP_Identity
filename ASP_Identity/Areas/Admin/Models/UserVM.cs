using Microsoft.AspNetCore.Mvc;

namespace ASP_Identity.Areas.Admin.Models;

public class UserVM 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
