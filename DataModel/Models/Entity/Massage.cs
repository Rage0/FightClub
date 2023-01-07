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
    public class Massage : IEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        [Required]
        public string AuthorId { get; set; } = "NoName";
        public User? Author { get; set; }
    }
}
