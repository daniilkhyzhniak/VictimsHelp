using Google.Apis.Calendar.v3.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.BLL.Contracts
{
    public interface IGoogleCalendarApiService
    {
        Task<IList<Event>> GetUpcomingEventsAsync(string email);
        Task<string> OrganizeMeetingAsync(OrganizeEventModel model);
        Task<string> OrganizeEmergencyMeetingAsync(string clientEmail);
    }
}
