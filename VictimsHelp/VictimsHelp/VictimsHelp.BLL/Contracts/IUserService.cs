using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.BLL.Contracts
{
    public interface IUserService
    {
        Task<bool> CreateAsync(UserModel model);
        Task<bool> EditAsync(UserModel model);
        Task DeleteByEmailAsync(string email);
        Task<UserModel> GetByEmailAsync(string email);
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<IEnumerable<Claim>> AuthenticateAsync(UserModel model);
    }
}
