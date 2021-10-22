using System.ComponentModel.DataAnnotations;

namespace Homework10.Models
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "PassError")]
        public string Password { get; set; }
    }
}
