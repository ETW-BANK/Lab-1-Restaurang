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
    public class CustomerRepository:Repository<Customer>, ICustomerRepository
    {
        private readonly RestaurantDbContext _db;
        public CustomerRepository(RestaurantDbContext db):base(db)
        {
            _db = db;   
        }

        public void Update(Customer customer)
        {
            _db.Customer.Update(customer);
        }

    
    }
}
