using Microsoft.AspNetCore.Mvc;

namespace FightClub.Controllers
{
    public class PostController : Controller
    {
        public IActionResult PostWall()
        {
            return View();
        }
    }
}
