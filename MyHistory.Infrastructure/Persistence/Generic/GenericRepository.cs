using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyHistory.Application.Common.Interfaces.Generic;
using MyHistory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Infrastructure.Persistence.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MyHistoryDbContext _dbContext;

        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(MyHistoryDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _logger = logger;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
