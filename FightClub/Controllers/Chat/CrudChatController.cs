using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class CrudChatController : Controller
    {
        private IRepositoryContext _context;
        public CrudChatController(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateChat(Chat chat, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                await _context.AddEntityToDbAsync<Chat>(chat);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultChatUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to create chat");
            }
        }

        public async Task<IActionResult> CreateRangeChat(Chat[] chats, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                await _context.AddRangeEntityToDbAsync<Chat>(chats);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultChatUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to range create chat");
            }
        }

        public IActionResult RemoveChat(Guid chatId, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                Chat? chat = _context.GetAllEntityOfDb<Chat>()
                    .FirstOrDefault(chatContext => chatContext.Id == chatId);
                if (chat != null)
                {
                    _context.RemovetEntityToDb<Chat>(chat);
                }

                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultChatUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to remove chat");
            }
        }

        public IActionResult RemoveRangeChat(Chat[] chats, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                _context.RemovetRangeEntityToDb<Chat>(chats);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultChatUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to range remove chat");
            }
        }

        public IActionResult UpdateChat(Chat chat, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                _context.UpdateEntityToDb<Chat>(chat);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultChatUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to update chat");
            }
        }

        private IActionResult DefaultChatUrl()
        {
            return RedirectToAction("AllChats", "Chat");
        }
    }
}
