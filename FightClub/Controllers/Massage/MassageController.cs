using DataModel.Interfaces;
using DataModel.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetworkClub.Controllers.Massage
{
    [Authorize]
    public class MassageController : Controller
    {
        private IRepositoryContext _context;
        public MassageController(IRepositoryContext context)
        {
            _context = context;
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
