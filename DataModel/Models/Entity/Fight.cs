using DataModel.Interfaces;
using DataModel.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entity
{
    public class Fight : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<UserProfile> Members { get; set; } = new List<UserProfile>();
        public ICollection<Bet> BetBank { get; set; } = new HashSet<Bet>();
        public bool CloseBet { get; set; } = false;
        public DateTime StartAtFight { get; set; }
        public DateTime EndAtFight { get;}
    }
}
