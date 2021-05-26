using System;

namespace VictimsHelp.PL.ViewModels.Calendar
{
    public class EventViewModel
    {
        public string Summary { get; set; }
        public string HangoutLink { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
