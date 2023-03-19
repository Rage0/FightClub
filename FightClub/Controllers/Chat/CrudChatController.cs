using DataModel.Interfaces;
using DataModel.Models.Entity;
using DataModel.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetworkClub.Controllers.Chat
{
    [Authorize]
    public class CrudChatController : Controller
    {
        private IRepositoryContext _context;
        private UserManager<UserProfile> _userManager;
        public CrudChatController(IRepositoryContext context, UserManager<UserProfile> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region Create Chat
        public async Task<IActionResult> CreateChat(Chat chat, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                chat.ProfileId = UserIdFactory(User.Identity.Name);
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
                await _context.AddRangeEntityToDbAsync(chats);
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
        #endregion

        #region Remove Chat
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
                _context.RemovetRangeEntityToDb(chats);
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
        #endregion

        #region Update Chat
        public IActionResult UpdateChat(Chat chat, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                chat.ProfileId = UserIdFactory(User.Identity.Name);
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
        #endregion

        private IActionResult DefaultChatUrl()
        {
            return RedirectToAction("AllChats", "Chat");
        }
        private string UserIdFactory(string username)
        {
            UserProfile? user = _userManager.FindByNameAsync(username).Result;
            return user.Id;
        }
    }
}
