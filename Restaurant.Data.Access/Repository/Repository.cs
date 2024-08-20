using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RestaurantDbContext _db;
        internal DbSet<T> Set;

        public Repository(RestaurantDbContext db)
        {
            _db = db;
            this.Set = _db.Set<T>();
         
        }

        public async Task AddAsync(T entity)
        {
            await Set.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null, bool? AsNoTracking = false)
        {
            IQueryable<T> query = Set;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }



        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool asNoTracking = false)
        {
            IQueryable<T> query = Set;

         
            query = query.Where(filter);

           
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

          
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

          
            return await query.FirstOrDefaultAsync();
        }


        public void Remove(T entity)
        {
            Set.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);
        }
    }
}

