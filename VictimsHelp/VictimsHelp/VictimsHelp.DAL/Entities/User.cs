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

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
