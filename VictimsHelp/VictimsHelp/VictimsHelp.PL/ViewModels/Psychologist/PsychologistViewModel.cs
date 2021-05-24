using System.ComponentModel.DataAnnotations;

namespace VictimsHelp.PL.ViewModels.Psychologist
{
    public class PsychologistViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}
