using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.BLL.Contracts
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageModel>> GetMessagesAsync(string email1, string email2);
        Task<bool> SendMessageAsync(MessageModel model);
    }
}
