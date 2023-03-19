using DataModel.Models.Identity;
using FightClub.Infrastructure.Model_Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetworkClub.Controllers.Account.Authorize
{
    [AllowAnonymous]
    public class SignInController : Controller
    {
        private SignInManager<UserProfile> _signInManager;
        private UserManager<UserProfile> _userManager;
        public SignInController(SignInManager<UserProfile> signInManager, UserManager<UserProfile> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            return View(new SignInModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            UserProfile? user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("PostWall", "Post");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("PostWall", "Post");
        }
    }
}
