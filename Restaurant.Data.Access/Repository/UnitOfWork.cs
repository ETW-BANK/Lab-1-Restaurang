using Restaurant.Data.Access.Data;
using Restaurant.Data.Access.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Access.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly RestaurantDbContext _db;
        public ICustomerRepository Customer { get; private set; }

        public ITableRepository Table { get; private set; }
        public IMenuRepository Menu { get; private set; }

        public IBookingRepository Booking { get; private set; }

        public UnitOfWork(RestaurantDbContext db)
        {

            _db = db;

            Customer = new CustomerRepository(_db);
            Table = new TableRepository(_db);
            Menu=new MenuRepository(_db);
            Booking=new BookingRepository(_db); 

        }



        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
