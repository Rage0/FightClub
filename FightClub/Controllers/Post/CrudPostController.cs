using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FightClub.Controllers
{
    public class CrudPostController : Controller
    {
        private IRepositoryContext _context;
        public CrudPostController(IRepositoryContext context)
        {
            _context = context;
        }

        #region Create Post
        public async Task<IActionResult> CreatePost(Post post, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                await _context.AddEntityToDbAsync<Post>(post);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to create post");
            }
        }

        public async Task<IActionResult> CreateRangePost(Post[] posts, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                await _context.AddRangeEntityToDbAsync<Post>(posts);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to range create post");
            }
        }
        #endregion

        #region Remove Post
        public async Task<IActionResult> RemovePost(Guid postId, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                Post? post = await _context.GetAllEntityOfDb<Post>()
                    .FirstOrDefaultAsync(postContext => postContext.Id == postId);
                if (post != null)
                {
                    _context.RemovetEntityToDb<Post>(post);
                }
                
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to remove post");
            }
        }


        public IActionResult RemoveRangePost(Post[] posts, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                _context.RemovetRangeEntityToDb<Post>(posts);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to range remove post");
            }
        }
        #endregion

        #region Update Post
        public IActionResult UpdatePost (Post post, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                _context.UpdateEntityToDb<Post>(post);
                if (string.IsNullOrEmpty(returnUrl) || string.IsNullOrWhiteSpace(returnUrl))
                {
                    return DefaultPostUrl();
                }
                return Redirect(returnUrl);
            }
            else
            {
                return BadRequest("Not valid to update post");
            }
        }
        #endregion

        private IActionResult DefaultPostUrl()
        {
            return RedirectToAction("PostWall", "Post");
        }
    }
}
