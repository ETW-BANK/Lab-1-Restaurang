using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TableController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllTables")]
        public async Task<IActionResult> GetAllTables()
        {
            IEnumerable<Tables> ListOfTables = await _unitOfWork.Table.GetAllAsync();

            return Ok(ListOfTables);
        }

        [HttpGet]
        [Route("GetTable")]
        public async Task<IActionResult> GetSingleTable(int id)
        {

            Tables table = await _unitOfWork.Table.GetSingleAsync(u => u.Id == id);
            return Ok(table);
        }

        [HttpPost]
        [Route("CreateTable")]

        public async Task<IActionResult> CreateNewCustomer([FromBody] Tables NewTable)
        {

            if (NewTable == null)
            {
                return BadRequest();
            }



            await _unitOfWork.Table.AddAsync(NewTable);

            await _unitOfWork.SaveAsync();

            return Ok();


        }


        [HttpPut]
        [Route("UpdateTable")]
        public async Task<IActionResult> UpdateTable(int id, [FromBody] Tables updatedTable)
        {

            Tables ExistingTable = await _unitOfWork.Table.GetSingleAsync(u => u.Id == id);

            if (ExistingTable == null)
            {
                return NotFound();
            }

            ExistingTable.TableNumber = updatedTable.TableNumber;
            ExistingTable.NumberOfSeats = updatedTable.NumberOfSeats;
            ExistingTable.IsBooked = updatedTable.IsBooked;


            _unitOfWork.Table.Update(ExistingTable);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTable")]
        public async Task<IActionResult> DeleteSingleTable(int id)
        {
            Tables table = await _unitOfWork.Table.GetSingleAsync(u => u.Id == id);

            if (table == null)
            {
                return NotFound();
            }

            _unitOfWork.Table.Remove(table);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

    }
}
