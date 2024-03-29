﻿using System.ComponentModel.DataAnnotations;

namespace FightClub.Infrastructure.Model_Authorize
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
