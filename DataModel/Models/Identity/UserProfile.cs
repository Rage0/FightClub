using DataModel.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Identity
{
    public class UserProfile : IdentityUser
    {
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public Club? Club { get; set; }
        public Guid? ClubId { get; set; }
        public ICollection<Massage> Massages { get; set; } = new List<Massage>();
        public ICollection<Chat> OwnerChats { get; set; } = new List<Chat>();
    }
}
