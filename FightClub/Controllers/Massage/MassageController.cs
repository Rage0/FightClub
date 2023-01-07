using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class MassageController : Controller
    {
        private IRepositoryContext _context;
        public MassageController(IRepositoryContext context)
        {
            _context = context;
        }

        public IActionResult CreateMassageToChat(Massage userMassage, Guid chatId, string otherReturnUrl)
        {
            Chat? chat = _context.GetAllEntityOfDb<Chat>()
                .FirstOrDefault(chatContext => chatContext.Id == chatId);
            if (chat != null)
            {
                chat.Massages.Add(userMassage);
                return RedirectToAction("CreateMassage", "CrudMassage", new { massage = userMassage, returnUrl = otherReturnUrl });
            }
            else
            {
                return BadRequest("Chat is not exist for massage");
            }
        }

        public IActionResult EditMassage(Guid massageId, string returnUrl)
        {
            Massage? massage = _context.GetAllEntityOfDb<Massage>()
                .FirstOrDefault(massageContext => massageContext.Id == massageId);
            if (massage != null)
            {
                return View(massage);
            }
            return Redirect(returnUrl);
        }
    }
}
