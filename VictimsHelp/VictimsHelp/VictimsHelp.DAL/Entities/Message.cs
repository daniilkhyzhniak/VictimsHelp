using System;

namespace VictimsHelp.DAL.Entities
{
    public class Message : BaseEntity
    {
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
