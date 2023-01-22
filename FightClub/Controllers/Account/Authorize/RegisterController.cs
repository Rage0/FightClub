using DataModel.Interfaces;
using DataModel.Models.Identity;
using FightClub.Infrastructure.Model_Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private SignInManager<UserProfile> _signInManager;
        private UserManager<UserProfile> _userManager;
        public RegisterController(SignInManager<UserProfile> signInManager, UserManager<UserProfile> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid && model.Password == model.PasswordConfirm)
            {
                UserProfile user = new UserProfile
                {
                    UserName = model.Name,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("PostWall", "Post");
                }
                else
                {
                    return BadRequest("User not created");
                }
            }
            else
            {
                return View(model);
            }

        }
    }
}
