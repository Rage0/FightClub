using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightClub.Controllers
{
    public class PostController : Controller
    {
        private IRepositoryContext _context;
        public PostController(IRepositoryContext context)
        {
            _context = context;
        }

        public IActionResult PostWall()
        {
            return View(_context.GetAllEntityOfDb<Post>()
                .Include(post => post.Comments)
                .AsEnumerable());
        }

        public IActionResult CreatePost()
        {
            return View(new Post());
        }
        
        public async Task<IActionResult> EditPost(Guid postId)
        {
            Post? post = await _context.GetAllEntityOfDb<Post>()
                .FirstOrDefaultAsync(contextPost => contextPost.Id == postId);
            if (post != null)
            {
                return View(post);
            }
            else
            {
                return PostWall();
            }
        }
    }
}
