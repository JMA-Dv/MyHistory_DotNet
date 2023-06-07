using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHistory.Application.Common.Interfaces.Generic
{
    /// <summary>
    /// Implenenting Unit Of work
    /// </summary>
    /// <typeparam name="T">This stands for all entities that requires CRUD operations</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> FindAsync(Expression<Func<T,bool>> expression);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
