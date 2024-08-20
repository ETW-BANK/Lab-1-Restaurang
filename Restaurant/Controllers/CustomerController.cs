using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;

namespace Restaurant.Controllers
{

     [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            IEnumerable<Customer> ListOfCustomers = await _unitOfWork.Customer.GetAllAsync();

            return Json(ListOfCustomers);  
        }


        [HttpGet]
        [Route("GetCoustomer")]
        public async Task <IActionResult> GetSingleCoustomer(int id)
        {

            Customer customer = await _unitOfWork.Customer.GetSingleAsync(u=>u.Id==id);
            return Json(customer);
        }

    

        [HttpPost]
        [Route("CreateCustomer")]

        public async Task<IActionResult> CreateNewCustomer([FromBody] Customer NewCustomer)
        {
            if (NewCustomer == null)
            {
                return BadRequest();
            }

               

         await _unitOfWork.Customer.AddAsync(NewCustomer);

         await _unitOfWork.SaveAsync();

            return Ok();

            
        }

        [HttpPut]
        [Route("UpdateCoustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {

            Customer Existingcustomer = await _unitOfWork.Customer.GetSingleAsync(u => u.Id == id);

            if (Existingcustomer == null)
            {
                return NotFound();
            }
           
            Existingcustomer.CustomerName= updatedCustomer.CustomerName;    
            Existingcustomer.Email= updatedCustomer.Email;  
            Existingcustomer.PhoneNumber= updatedCustomer.PhoneNumber;


          _unitOfWork.Customer.Update(Existingcustomer);
           await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCoustomer")]
        public async Task<IActionResult> DeleteSingleCustomer(int id)
        {

            Customer customer = await _unitOfWork.Customer.GetSingleAsync(u => u.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _unitOfWork.Customer.Remove(customer);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

    }
}
