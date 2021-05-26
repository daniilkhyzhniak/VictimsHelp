using Microsoft.Extensions.DependencyInjection;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.BLL.Services;
using VictimsHelp.DAL.Assistance;

namespace VictimsHelp.BLL.Assistance
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBll(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IPsychologistService, PsychologistService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IGoogleCalendarApiService, GoogleCalendarApiService>();
            services.AddDal(connectionString);
            services.AddAutoMapper(cfg => cfg.AddProfile<BllAutoMapperProfile>());
        }
    }
}
