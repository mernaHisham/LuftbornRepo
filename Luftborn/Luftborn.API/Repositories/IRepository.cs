using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Luftborn.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        DbContext Context { get; }
        IQueryable<T> GetAll();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);


    }
}
