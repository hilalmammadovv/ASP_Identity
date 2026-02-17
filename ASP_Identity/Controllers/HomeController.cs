using System.Diagnostics;
using ASP_Identity.Models;
using ASP_Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ASP_Identity.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ASP_Identity.Services;

namespace ASP_Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _UserManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> SignIn(SignInVM model, string? returnUrl = null)
        {



            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser = await _UserManager.FindByEmailAsync(model.Email);

            if (hasUser == null)
            {

                ModelState.AddModelError(string.Empty, "Email ve ya sifre yanlisdir");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);


            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 deqiqe muddetinde giris ede bilmezsiniz" });
                return View();
            }

            ModelState.AddModelErrorList(new List<string>() { "Email ve ya sifre yalnis" });

            ModelState.AddModelErrorList(new List<string>()
{
    $"Email və ya sifrə yalnış (Uğursuz giriş sayı: {await _UserManager.GetAccessFailedCountAsync(hasUser)})"
});





            return View();
        }



        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }
            var identityResult = await _UserManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, request.PasswordConfirm);

            if (identityResult.Succeeded)
            {
                TempData["SuccesMessage"] = "Qeydiyyat Ugurlu ! ";
                return RedirectToAction(nameof(HomeController.SignUp));
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());






            return View();
        }



        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM request)
        {
            var hasUser = await _UserManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "Bu email adresine sahib user tapilmamisdir.");
                return View();
            }

            string passwordResestToken = await _UserManager.GeneratePasswordResetTokenAsync(hasUser);

            var passwordResetLink = Url.Action("ResetPassword", "Home", new { userId = hasUser.Id, Token = passwordResestToken }, HttpContext.Request.Scheme);
           

            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);

            TempData["SuccessMessage"] = "Şifre yenileme linki emailinze gonderilib";

            return RedirectToAction(nameof(ForgetPassword));
        }



        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];

            if (userId == null || token == null)
            {
                throw new Exception("Bir xeta meydana geldi");
            }

            var hasUser = await _UserManager.FindByIdAsync(userId.ToString()!);


            if (hasUser == null)
            {
                ModelState.AddModelError(String.Empty, "User tapilmamisdir.");
                return View();
            }

            IdentityResult result = await _UserManager.ResetPasswordAsync(hasUser, token.ToString()!, request.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Şifreniz ugurla yenilenmisdir";
            }
            else
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
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
