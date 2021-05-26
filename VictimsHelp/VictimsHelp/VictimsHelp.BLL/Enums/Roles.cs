using System.Collections.Generic;

namespace VictimsHelp.BLL.Enums
{
    public class Roles
    {
        public const string Client = "Client";
        public const string Psychologist = "Psychologist";
        public const string Admin = "Admin";

        public static IEnumerable<string> GetAll()
        {
            return new List<string>
            {
                Client, Psychologist, Admin
            };
        }
    }
}
