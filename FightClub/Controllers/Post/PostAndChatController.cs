using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    public class PostAndChatController : Controller
    {
        private IRepositoryContext _context;
        public PostAndChatController(IRepositoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreatePostWithChat(Post post, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                Chat chat = new Chat
                {
                    Name = post.Title ?? string.Empty,
                    CreateAt = DateTime.UtcNow,
                };
                await _context.AddEntityToDbAsync<Chat>(chat);

                post.Comments = chat;
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
    }
}
