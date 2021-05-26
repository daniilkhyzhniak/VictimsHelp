using System;
using System.Collections.Generic;

namespace VictimsHelp.BLL.Models
{
    public class OrganizeEventModel
    {
        public string EventTitle { get; set; }
        public IList<string> Emails { get; set; } = new List<string>();
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
