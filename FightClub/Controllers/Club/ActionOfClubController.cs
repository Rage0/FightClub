using DataModel.Interfaces;
using DataModel.Models.Entity;
using FightClub.Infrastructure.TransientClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    public class ActionOfClubController : Controller
    {
        private ActionOfClub _actionClub;
        public ActionOfClubController(ActionOfClub actionOfClub)
        {
            _actionClub = actionOfClub;
        }

        public async Task<IActionResult> AddUserToClub(Guid clubId, string returnUrl)
        {
            await _actionClub.AddUserToMemberClubAsync(User.Identity.Name, clubId);
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> RemoveUserFromClub(Guid clubId, string returnUrl)
        {
            await _actionClub.RemoveUserFromMemberClubAsync(User.Identity.Name, clubId);
            return Redirect(returnUrl);
        }
    }
}
