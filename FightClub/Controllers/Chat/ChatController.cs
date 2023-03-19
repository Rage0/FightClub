using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NetworkClub.Controllers.Chat
{
    public class ChatController : Controller
    {
        private IRepositoryContext _context;
        public ChatController(IRepositoryContext context)
        {
            _context = context;
        }

        public IActionResult AllChats()
        {
            return View(_context.GetAllEntityOfDb<Chat>()
                .Include(chat => chat.Profile));
        }

        [Authorize]
        public IActionResult CreateChat()
        {
            return View(new Chat());
        }

        public IActionResult ChattingRoom(Guid chatId)
        {
            Chat? chat = _context.GetAllEntityOfDb<Chat>()
                .Include(chatContext => chatContext.Massages)
                .FirstOrDefault(chatContext => chatContext.Id == chatId);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return BadRequest("Chat is not exist");
            }
        }

        [Authorize]
        public IActionResult EditChat(Guid chatId)
        {
            Chat? chat = _context.GetAllEntityOfDb<Chat>()
                .FirstOrDefault(chatContext => chatContext.Id == chatId);
            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return AllChats();
            }
        }
    }
}
