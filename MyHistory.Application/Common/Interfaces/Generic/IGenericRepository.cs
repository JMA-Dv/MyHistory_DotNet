using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
