using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Models;

namespace VictimsHelp.BLL.Contracts
{
    public interface IPsychologistService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByEmailAsync(string email);
        Task<bool> SignDeclarationAsync(string psychologistEmail, string clientEmail);
        Task<IEnumerable<UserModel>> GetClientsAsync(string psychologistEmail);
    }
}
