using System.ComponentModel.DataAnnotations;

namespace VictimsHelp.PL.ViewModels.Account
{
    public class ProfileViewModel
    {
        [EmailAddress(ErrorMessage = "Invalid format for email field")]
        [Display(Name = "Email")]
        [Editable(false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name field is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name field is required")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [Phone(ErrorMessage = "The Phone number field is not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Psychologist email")]
        public string PsychologistEmail { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
