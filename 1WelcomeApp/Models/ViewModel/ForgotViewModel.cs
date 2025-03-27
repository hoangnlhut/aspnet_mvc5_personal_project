using System.ComponentModel.DataAnnotations;

namespace _1WelcomeApp.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
