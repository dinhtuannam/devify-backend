using Castle.Core.Logging;
using Devify.Application.Interfaces;
using Devify.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devify.Infrastructure.SeedWorks
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
    
        public virtual async Task<bool> AddAsAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual Task<bool> UpdateAsAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
