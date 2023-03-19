using DataModel.Interfaces;
using DataModel.Models.Entity;
using DataModel.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NetworkClub.Infrastructure.TransientClasses
{
    public class ActionOfClub
    {
        private UserManager<UserProfile> _userManager;
        private IRepositoryContext _context;
        public ActionOfClub(UserManager<UserProfile> userManager, IRepositoryContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task AddUserToMemberClubAsync(string userName, Guid clubId)
        {
            UserProfile? user = await _userManager.FindByNameAsync(userName);
            Club? club = await _context.GetAllEntityOfDb<Club>()
                .Include(clubContext => clubContext.Members)
                .FirstOrDefaultAsync(clubContext => clubContext.Id == clubId);
            if (club != null && user != null)
            {
                club.Members.Add(user);
                _context.UpdateEntityToDb(club);
            }
        }

        public async Task RemoveUserFromMemberClubAsync(string userName, Guid clubId)
        {
            UserProfile? user = await _userManager.FindByNameAsync(userName);
            Club? club = await _context.GetAllEntityOfDb<Club>()
                .Include(clubContext => clubContext.Members)
                .FirstOrDefaultAsync(clubContext => clubContext.Id == clubId);
            if (club != null && user != null)
            {
                club.Members.Remove(user);
                _context.UpdateEntityToDb(club);
            }
        }

        public async Task RemoveAllUsersFromMemberClubAsync(Guid clubId)
        {
            var users = _userManager.Users;
            Club? club = await _context.GetAllEntityOfDb<Club>()
                .Include(clubContext => clubContext.Members)
                .FirstOrDefaultAsync(clubContext => clubContext.Id == clubId);
            if (club != null)
            {
                club.Members.ToList().Clear();
                _context.UpdateEntityToDb(club);
            }
        }
    }
}
