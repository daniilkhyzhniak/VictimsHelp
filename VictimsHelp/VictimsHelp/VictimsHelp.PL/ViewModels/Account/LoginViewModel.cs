using System.ComponentModel.DataAnnotations;

namespace VictimsHelp.PL.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email field is required")]
        [EmailAddress(ErrorMessage = "Invalid format for email field")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
