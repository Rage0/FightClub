using DataModel.Models.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Identity
{
    public class User : IdentityUser
    {
        public decimal CashAccount { get; set; } = decimal.Zero;
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public Club? Club { get; set; }
        public ICollection<Bet> Bets { get; set; } = new List<Bet>();
        public ICollection<Massage> Massages { get; set; } = new List<Massage>();
        public ICollection<Chat> OwnerChats { get; set; } = new List<Chat>();
    }
}
