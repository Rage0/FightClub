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
    public class Post : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Chat? Comments { get; set; }
        [Required]
        public string ProfileId { get; set; } = "NoName";
        public UserProfile? Profile { get; set; }
    }
}
