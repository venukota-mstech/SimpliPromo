using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpliPromo.Entities;
using SimpliPromo.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpliPromo.Controllers
{
    public class MainController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public MainController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //SeedData.Seed(_simpliPromoContext);
            //ViewBag.value = "SimpliPromo!!!";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResults = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe,lockoutOnFailure:false);
                if (loginResults.Succeeded)
                    {
                    return RedirectToAction("Index", "LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login information");
                }
            }

            return View(model);
        }   
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var identityUser = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.UserName
                };
                var identityResults = await _userManager.CreateAsync(identityUser, model.Password);
                if (identityResults.Succeeded)
                {
                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    return RedirectToAction("Index", "LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in creating the user");
                }
            }
            return View(model);
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            return View();
        }
    }
}