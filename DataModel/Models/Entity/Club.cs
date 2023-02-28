using DataModel.Interfaces;
using DataModel.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel.Models.Entity
{
    public class Club : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Chat? ChatClub { get; set; }
        public ICollection<UserProfile> Members { get; set; } = new List<UserProfile>();
        public DateTime CreateAt { get; set; }
        public string? CreaterId { get; set; } = "NoName";
    }
}
