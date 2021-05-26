using System.Collections.Generic;

namespace VictimsHelp.DAL.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PsychologistEmail { get; set; }

        public User Psychologist { get; set; }
        public ICollection<User> Clients { get; set; } = new List<User>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
