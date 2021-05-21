using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.DAL.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetOneAsync(Expression<Func<T, bool>> expression);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteByIdAsync(Expression<Func<T, bool>> expression);
    }
}
