using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.PL.ViewModels.Account;
using Route.C41.MVC.DAL.Models;
using System.Threading.Tasks;
namespace Route.C41.MVC.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        #region SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(signUpViewModel.UserName);
                if (user is null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = signUpViewModel.UserName,
                        Email = signUpViewModel.Email,
                        IsAgree = signUpViewModel.IsAgree,
                        FName = signUpViewModel.FName,
                        LName = signUpViewModel.LName,
                    };
                    var result = await _userManager.CreateAsync(user, signUpViewModel.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    else
                    {
                        return RedirectToAction(nameof(SignIn));
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username is in use");
                }
            }
            return View(signUpViewModel);
        }
        #endregion
        #region SignIn
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            if(ModelState.IsValid) {
                var user = await _userManager.FindByEmailAsync(signInViewModel.Email);
                if(user is not null)
                {
                    var isPasswordCorrect= await _userManager.CheckPasswordAsync(user, signInViewModel.Password);
                    if (isPasswordCorrect)
                    {
                        var signInAttempt= await _signInManager.PasswordSignInAsync(user, signInViewModel.Password, true, false);

                        if (signInAttempt.IsNotAllowed)
						{
                            ModelState.AddModelError(string.Empty, "You are not allowed");
						}

                        if(signInAttempt.IsLockedOut)
                        {
							ModelState.AddModelError(string.Empty, "You are locked out");

						}

                        if (signInAttempt.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index),"Home");
                        }

					}
                }
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View(signInViewModel);
        }
        #endregion
    }
}
