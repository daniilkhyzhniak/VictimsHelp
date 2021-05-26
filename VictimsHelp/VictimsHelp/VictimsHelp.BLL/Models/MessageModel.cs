using System;

namespace VictimsHelp.BLL.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
