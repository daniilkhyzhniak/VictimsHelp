using System.Collections.Generic;

namespace VictimsHelp.DAL.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
