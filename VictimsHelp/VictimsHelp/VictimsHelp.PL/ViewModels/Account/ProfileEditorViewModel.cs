using System.ComponentModel.DataAnnotations;

namespace VictimsHelp.PL.ViewModels.Account
{
    public class ProfileEditorViewModel
    {
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
    }
}
