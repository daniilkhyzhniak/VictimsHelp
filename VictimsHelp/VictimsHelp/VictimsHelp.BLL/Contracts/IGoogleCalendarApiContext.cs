using Google.Apis.Http;

namespace VictimsHelp.BLL.Contracts
{
    public interface IGoogleCalendarApiContext
    {
        public string ApplicationName { get; set; }
        public IConfigurableHttpClientInitializer HttpClientInitializer { get; set; }
    }
}
