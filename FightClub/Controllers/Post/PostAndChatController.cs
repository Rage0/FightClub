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
    public class PostAndChatController : Controller
    {
        private IRepositoryContext _context;
        private UserManager<UserProfile> _userManager;
        public PostAndChatController(IRepositoryContext context, UserManager<UserProfile> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreatePostWithChat(Post post, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                Chat chat = new Chat
                {
                    ProfileId = UserIdFactory(User.Identity.Name),
                    Name = post.Title + "_postChat" ?? string.Empty,
                    CreateAt = DateTime.UtcNow,
                };
                await _context.AddEntityToDbAsync<Chat>(chat);

                post.Comments = chat;
                post.ProfileId = UserIdFactory(User.Identity.Name);
                await _context.AddEntityToDbAsync<Post>(post);

                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to create post with chat");
            }
        }

        public async Task<IActionResult> RemovePostWithChat(Guid postId, string returnUrl = "")
        {
            Post? post = await _context.GetAllEntityOfDb<Post>()
                .Include(postContext => postContext.Comments)
                    .ThenInclude(chat => chat.Massages)
                .FirstOrDefaultAsync(postContext => postContext.Id == postId);
            if (post != null)
            {
                if (post.Comments != null)
                {
                    _context.RemovetRangeEntityToDb<Massage>(post.Comments.Massages.ToArray());
                    _context.RemovetEntityToDb<Chat>(post.Comments);
                }

                _context.RemovetEntityToDb(post);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Post with chat is not exist");
            }
        }

        private IActionResult DefaultPostUrl()
        {
            return RedirectToAction("PostWall", "Post");
        }

        private string UserIdFactory(string username)
        {
            UserProfile? user = _userManager.FindByNameAsync(username).Result;
            return user.Id;
        }
    }
}
