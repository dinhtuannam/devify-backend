﻿using Devify.Application.Interfaces;
using Devify.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;

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

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<bool> AddAsAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                Console.WriteLine($"[AddAsAsync] -> successfully ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddAsAsync] -> failed -> Exception : {ex.Message}");
                return false;
            }
        }

        public virtual async Task<bool> DeleteAsAsync(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[DeleteAsAsync] -> failed -> Exception : {ex.Message}");
                return false;
            }
        }

        public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(condition);
            return query;
        }

        public virtual async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual bool UpdateEntity(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                Console.WriteLine($"[UpdateEntity] -> successfully ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateEntity] -> failed -> Exception : {ex.Message}");
                return false;
            }
        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }
    }
}
