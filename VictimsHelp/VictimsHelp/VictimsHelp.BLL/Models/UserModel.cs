﻿using System;
using System.Collections.Generic;

namespace VictimsHelp.BLL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PsychologistEmail { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
