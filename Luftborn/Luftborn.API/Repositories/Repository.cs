using Microsoft.EntityFrameworkCore;
using Luftborn.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Luftborn.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Repository() : this(new LuftbornDBContext()) { }

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

      

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
     
        public async Task<int> AddAsync(T entity)
        {
            int added;
            try
            {
                await _dbSet.AddAsync(entity);
                added = await SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return added;
        }
    

      


        public async Task<int> UpdateAsync(T entity)
        {
            int updated;
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                updated = await SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updated;
        }

      
        public Task<int> SaveAsync()
        {
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (Exception x)
            {

                throw x;
            }
        }

        

    }
}
