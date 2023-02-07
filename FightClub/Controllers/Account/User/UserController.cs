using DataModel.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    public class UserController : Controller
    {
        private UserManager<UserProfile> _userManager;
        public UserController(UserManager<UserProfile> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Profile(string userName)
        {
            UserProfile? user = await _userManager.Users
                .Include(userContext => userContext.Club)
                .SingleAsync(userContext => userContext.UserName == userName);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return BadRequest("User is not find");
            }
        }
    }
}
