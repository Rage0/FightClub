using System.ComponentModel.DataAnnotations;

namespace FightClub.Infrastructure.Model_Authorize
{
    public class SignInModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
