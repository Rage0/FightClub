using DataModel.Interfaces;
using DataModel.Models.Entity;
using DataModel.Models.Identity;
using FightClub.Infrastructure.TransientClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace FightClub.Controllers
{
    [Authorize]
    public class ClubAndChatController : Controller
    {
        private IRepositoryContext _context;
        private UserManager<UserProfile> _userManager;
        private ActionOfClub _actionClub;
        public ClubAndChatController(IRepositoryContext context, 
            UserManager<UserProfile> userManager,
            ActionOfClub actionClub)
        {
            _context = context;
            _userManager = userManager;
            _actionClub = actionClub;
        }

        public async Task<IActionResult> CreateClubWithChat(Club club, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                Guid clubid= Guid.NewGuid();

                Chat chat = new Chat()
                {
                    Name = club.Name + "_clubChat",
                    Profile = GetUser(username).Result,
                    ProfileId = GetUser(username).Result.Id
                };
                await _context.AddEntityToDbAsync<Chat>(chat);

                club.Id = clubid;
                club.ChatClub = chat;
                club.CreaterId = GetUser(username).Result.Id;
                club.CreateAt = DateTime.UtcNow;
                await _context.AddEntityToDbAsync<Club>(club);

                await _actionClub.AddUserToMemberClubAsync(username, clubid);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultClubUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("It is not valid");
            }
        }

        public async Task<IActionResult> RemoveClubWithChat(Guid clubId, string returnUrl = "")
        {
            Club? club = await _context.GetAllEntityOfDb<Club>()
                .Include(clubs => clubs.ChatClub)
                    .ThenInclude(chat => chat.Massages)
                .FirstOrDefaultAsync(clubs => clubs.Id == clubId);
            if (club != null)
            {
                if (club.ChatClub != null && club.ChatClub.Massages != null)
                {
                    _context.RemovetRangeEntityToDb<Massage>(club.ChatClub.Massages.ToArray());
                    _context.RemovetEntityToDb<Chat>(club.ChatClub);
                }

                await _actionClub.RemoveAllUsersFromMemberClubAsync(club.Id);
                _context.RemovetEntityToDb<Club>(club);

                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultClubUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Club with chat is not exist");
            }
        }

        public async Task<IActionResult> UpdateClubWithChat(Club club, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                club.CreaterId = GetUser(User.Identity.Name).Result.Id;

                _context.UpdateEntityToDb<Club>(club);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultClubUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Club is not valid");
            }
        }

        private async Task<UserProfile> GetUser(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        private IActionResult DefaultClubUrl()
        {
            return RedirectToAction("AllClubs", "Club");
        }
        
    }
}
