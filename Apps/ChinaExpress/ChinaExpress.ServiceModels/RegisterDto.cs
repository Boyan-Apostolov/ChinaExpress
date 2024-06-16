using System.ComponentModel.DataAnnotations;

namespace ChinaExpress.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }

        [Required]
        public string Phone { get; set; }

        public string? Message { get; set; }

        public int? ReferralUserId { get; set; }

    }
}
