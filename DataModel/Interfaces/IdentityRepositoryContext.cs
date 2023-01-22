using DataModel.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Interfaces
{
    public interface IdentityRepositoryContext
    {
        public IQueryable<UserProfile> GetAllUserProfiles();
        public Task AddUserProfile(UserProfile profile);
        public void UpdateUserProfile(UserProfile profile);
        public void RemovetUserProfile(UserProfile profile);
    }
}
