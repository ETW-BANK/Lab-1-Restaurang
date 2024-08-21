using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       


        [HttpGet]
        [Route("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _unitOfWork.Booking.GetAllAsync(includeProperties: "customer,table");
            return Ok(bookings);
        }

        [HttpGet]
        [Route("GetBooking/{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var booking = await _unitOfWork.Booking.GetSingleAsync(b => b.Id == id, includeProperties: "customer,table");
            if (booking == null)
            {
                return NotFound("Booking not found.");
            }
            return Ok(booking);
        }

        //[HttpPut]
        //[Route("UpdateBooking/{id}")]
        //public async Task<IActionResult> UpdateBooking(int id, [FromBody] Booking updatedBooking)
        //{
        //    var existingBooking = await _unitOfWork.Booking.GetSingleAsync(b => b.Id == id);
        //    if (existingBooking == null)
        //    {
        //        return NotFound("Booking not found.");
        //    }

        //    if (existingBooking.TableId != updatedBooking.TableId)
        //    {
        //        var oldTable = await _unitOfWork.Table.GetSingleAsync(t => t.Id == existingBooking.TableId);
        //        if (oldTable != null)
        //        {
        //            oldTable.IsBooked = false;
        //            _unitOfWork.Table.Update(oldTable);
        //        }

        //        var newTable = await _unitOfWork.Table.GetSingleAsync(t => t.Id == updatedBooking.TableId && !t.IsBooked && t.NumberOfSeats >= updatedBooking.NumberOfGuests);
        //        if (newTable == null)
        //        {
        //            return BadRequest("The new table is not available or cannot accommodate the number of guests.");
        //        }

        //        newTable.IsBooked = true;
        //        _unitOfWork.Table.Update(newTable);

        //        existingBooking.TableId = updatedBooking.TableId;
        //    }

          
        //    existingBooking.BookingDate = updatedBooking.BookingDate;
        //    existingBooking.NumberOfGuests = updatedBooking.NumberOfGuests;
        //    existingBooking.CustomerId = updatedBooking.CustomerId;
         

        //    _unitOfWork.Booking.Update(existingBooking);
        //    await _unitOfWork.SaveAsync();

        //    return Ok("Booking successfully updated.");
        //}

        [HttpDelete]
        [Route("DeleteBooking/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _unitOfWork.Booking.GetSingleAsync(b => b.Id == id);
            if (booking == null)
            {
                return NotFound("Booking not found.");
            }

            var table = await _unitOfWork.Table.GetSingleAsync(t => t.Id == booking.TableId);
            if (table != null)
            {
                table.IsBooked = false;
                _unitOfWork.Table.Update(table);
            }

            _unitOfWork.Booking.Remove(booking);
            await _unitOfWork.SaveAsync();

            return Ok("Booking successfully deleted.");
        }
    }
}
