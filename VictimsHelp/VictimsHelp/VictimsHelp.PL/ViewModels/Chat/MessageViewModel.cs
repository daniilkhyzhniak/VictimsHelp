using System.Collections.Generic;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.PL.ViewModels.Chat
{
    public class MessageViewModel
    {
        public ICollection<MessageModel> Messages { get; set; }
        public MessageModel Message { get; set; }
    }
}
