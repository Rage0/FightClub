using DataModel.Interfaces;
using DataModel.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entity
{
    public class Chat : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        public ICollection<Massage> Massages { get; set; } = new List<Massage>();
        public DateTime CreateAt { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? PostId { get; set; }
        [Required]
        public string ProfileId { get; set; } = "NoName";
        public UserProfile? Profile { get; set; }
    }
}
