using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Data.Access.Repository
{
    public class TableRepository : Repository<Tables>, ITableRepository
    {

        private readonly RestaurantDbContext _db;

        public TableRepository(RestaurantDbContext db):base(db) 
        {
            _db = db;
        }
        public void Update(Tables tables)
        {
            _db.Table.Update(tables);
        }
    }
}
