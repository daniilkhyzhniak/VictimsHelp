using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VictimsHelp.DAL.Assistance
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDal(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
