using Devify.Application.Interfaces;
using Devify.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Devify.Infrastructure.SeedWorks
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // ===================================== QUERIES ======================================= 
        public virtual IQueryable<T> GetCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(condition);
            return query;
        }
        public virtual IQueryable<T> GetID(string id, int delete)
        {
            IQueryable<T> query = _dbSet;

            if (delete == 1)
            {
                query = query.Where(e => EF.Property<string>(e, "id") == id && EF.Property<bool>(e, "isdeleted") == true);
            }
            else if (delete == 0)
            {
                query = query.Where(e => EF.Property<string>(e, "id") == id && EF.Property<bool>(e, "isdeleted") == false);
            }
            else
            {
                query = query.Where(e => EF.Property<string>(e, "id") == id);
            }

            return query.AsQueryable();
        }
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual IQueryable<T> GetContains(List<string> codes)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(e => codes.Contains(EF.Property<string>(e, "code")));
            return query.AsQueryable();
        }

        public virtual IQueryable<T> GetCode(string code, int delete)
        {
            IQueryable<T> query = _dbSet;

            if (delete == 1)
            {
                query = query.Where(e => EF.Property<string>(e, "code") == code && EF.Property<bool>(e, "isdeleted") == true);
            }
            else if (delete == 0)
            {
                query = query.Where(e => EF.Property<string>(e, "code") == code && EF.Property<bool>(e, "isdeleted") == false);
            }
            else
            {
                query = query.Where(e => EF.Property<string>(e, "code") == code);
            }

            return query.AsQueryable();
        }

        public T GetRawEntityByCode(string code)
        {
            T? data = _dbSet.Where(s => EF.Property<string>(s, "code") == code).FirstOrDefault();    
            if(data == null)
            {
                return null;
            }
            return data;
        }


        // ===================================== COMMANDS ======================================= 
        public virtual bool Insert(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual bool Delete(T entity)
        {
            try
            {
                 _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual bool Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
