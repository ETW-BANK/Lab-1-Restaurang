using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        Task AddAsync(T entity); 

        void Remove(T entity); 

        void RemoveRange(IEnumerable<T> entities);  

        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool AsNoTracking=false);  

        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null, bool? AsNoTracking = false);



    }
}
