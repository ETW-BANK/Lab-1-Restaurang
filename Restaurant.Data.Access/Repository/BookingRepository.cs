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
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly RestaurantDbContext _db;

        public BookingRepository(RestaurantDbContext db):base(db) 
        {
            _db = db;
        }
        public void Update(Booking booking)
        {
            _db.Bookings.Update(booking);   
        }
    }
}
