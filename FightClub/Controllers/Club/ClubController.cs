using DataModel.Interfaces;
using DataModel.Models.Entity;
using DataModel.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NetworkClub.Controllers.Club
{
    public class ClubController : Controller
    {
        private IRepositoryContext _context;
        private UserManager<UserProfile> _userManager;
        public ClubController(IRepositoryContext context, UserManager<UserProfile> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult YourClub(Club club)
        {
            return View(club);
        }

        public IActionResult AllClubs()
        {
            return View(_context.GetAllEntityOfDb<Club>()
                .Include(club => club.Members));
        }

        public async Task<IActionResult> ClubProfile(Guid clubId)
        {
            Club? club = await _context.GetAllEntityOfDb<Club>()
                .Include(clubContext => clubContext.ChatClub)
                .Include(clubContext => clubContext.Members)
                .FirstOrDefaultAsync(clubContext => clubContext.Id == clubId);
            if (club != null)
            {
                ViewBag.NameCreaterOfClub = _userManager.FindByIdAsync(club.CreaterId).Result.UserName;
                return View(club);
            }
            else
            {
                return BadRequest("Club is not exist");
            }
        }

        public async Task<IActionResult> EditClub(Guid clubId)
        {
            Club? club = await _context.GetAllEntityOfDb<Club>()
                .FirstOrDefaultAsync(club => club.Id == clubId);
            if (club != null)
            {
                return View(club);
            }
            else
            {
                return BadRequest("Club not exist");
            }
        }

        [Authorize]
        public IActionResult CreateClub()
        {
            return View(new Club());
        }
    }
}
