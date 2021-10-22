using System.ComponentModel.DataAnnotations;

namespace Homework10.Models
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
