using DataModel.Interfaces;
using DataModel.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entity
{
    public class Club : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public Chat? ChatClub { get; set; }
        public ICollection<UserProfile> Members { get; set; } = new List<UserProfile>();
        public DateTime CreateAt { get; set; }
        [Required]
        public string ProfileId { get; set; } = "NoName";
        [NotMapped]
        public UserProfile? Profile { get; set; }
    }
}
