using System.Threading.Tasks;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.DAL.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>()
            where T : BaseEntity;
        Task CommitAsync();
    }
}
