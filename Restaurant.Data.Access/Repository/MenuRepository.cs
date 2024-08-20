using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {

        private readonly RestaurantDbContext _db;

        public MenuRepository(RestaurantDbContext db):base(db) 
        {
            _db = db;
        }
        public void Update(Menu menu)
        {
           _db.Menu.Update(menu);   
        }
    }
}
