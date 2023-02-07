using DataModel.Interfaces;
using DataModel.Models.Entity;
using DataModel.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    [Authorize]
    public class CrudMassageController : Controller
    {
        private IRepositoryContext _context;
        private UserManager<UserProfile> _userManager;
        public CrudMassageController(IRepositoryContext context, UserManager<UserProfile> userManage)
        {
            _context = context;
            _userManager = userManage;
        }

        public async Task<IActionResult> CreateMassageToChat(Massage massage, Guid chatId, string returnUrl)
        {
            Chat? chat = await _context.GetAllEntityOfDb<Chat>()
                .FirstOrDefaultAsync(chatContext => chatContext.Id == chatId);
            if (ModelState.IsValid && chat != null)
            {
                massage.ProfileId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                chat.Massages.Add(massage);
                await _context.AddEntityToDbAsync<Massage>(massage);
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Chat is not exist or massage is not valid");
            }
            
        }

        public async Task<IActionResult> CreateMassage(Massage massage, string returnUrl)
        {;
            if (ModelState.IsValid)
            {
                await _context.AddEntityToDbAsync<Massage>(massage);
            }
            return Redirect(returnUrl);
        }

        public IActionResult RemoveMassage(Guid massageId, string returnUrl)
        {
            Massage? massage = _context.GetAllEntityOfDb<Massage>()
                .FirstOrDefault(massageContext => massageContext.Id == massageId);
            if (massage != null)
            {
                _context.RemovetEntityToDb<Massage>(massage);
            }
            return Redirect(returnUrl);
        }

        public IActionResult UpdateMassage(Massage massage, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                _context.UpdateEntityToDb<Massage>(massage);
            }
            return Redirect(returnUrl);
        }
    }
}
