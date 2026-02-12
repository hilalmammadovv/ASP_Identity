using System.Diagnostics;
using ASP_Identity.Models;
using ASP_Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> _UserManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {




            return View();
        }



        public IActionResult SignIn()
        {
            return View();
        }






        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
           

            if (!ModelState.IsValid) { 
            
                return View();            
            }
var identityResult = await _UserManager.CreateAsync(new () { UserName = request.UserName, PhoneNumber=request.Phone,Email=request.Email }, request.PasswordConfirm);

            if (identityResult.Succeeded)
            {
                TempData["SuccesMessage"] = "Qeydiyyat Ugurlu ! ";
                return RedirectToAction(nameof(HomeController.SignUp));
            }

            foreach (IdentityError item in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }



            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
