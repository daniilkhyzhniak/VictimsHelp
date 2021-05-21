using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VictimsHelp.DAL.Contracts;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> Entities;

        public GenericRepository(AppDbContext context)
        {
            Entities = context.Set<T>();
        }

        public async Task DeleteByIdAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await Entities.FirstOrDefaultAsync(expression);
            Entities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await Entities.Where(expression).ToListAsync();
        }

        public Task<T> GetOneAsync(Expression<Func<T, bool>> expression)
        {
            return Entities.FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
        }
    }
}
