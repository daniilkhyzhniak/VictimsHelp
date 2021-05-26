using Google.Apis.Http;
using VictimsHelp.BLL.Contracts;

namespace VictimsHelp.BLL.Models
{
    public class GoogleCalendarApiContext : IGoogleCalendarApiContext
    {
        public string ApplicationName { get; set; }
        public IConfigurableHttpClientInitializer HttpClientInitializer { get; set; }
    }
}
