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
    public class Bet : IEntity
    {
        public Guid Id { get; set; }
        public decimal Money { get; set; } = decimal.Zero;
        [Required]
        public string AuthorId { get; set; } = "NoName";
        public User? Author { get; set; }
    }
}
