using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Access.Repository.IRepository;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;

        public MenuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllMenu")]
        public async Task<IActionResult> GetAllMenus()
        {
            IEnumerable<Menu> ListOfmenu = await _unitOfWork.Menu.GetAllAsync();

            return Ok(ListOfmenu);
        }


        [HttpGet]
        [Route("GetSingleMenu")]
        public async Task<IActionResult> GetSingleMenu(int id)
        {

            Menu menu = await _unitOfWork.Menu.GetSingleAsync(u => u.Id == id);
            return Ok(menu);
        }



        [HttpPost]
        [Route("CreateMenu")]

        public async Task<IActionResult> CreateNewMenu([FromBody] Menu NewMenu)
        {
            if (NewMenu == null)
            {
                return BadRequest();
            }



            await _unitOfWork.Menu.AddAsync(NewMenu);

            await _unitOfWork.SaveAsync();

            return Ok();


        }

        [HttpPut]
        [Route("UpdateMenu")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] Menu updatedMenu)
        {

            Menu Existingmenu = await _unitOfWork.Menu.GetSingleAsync(u => u.Id == id);

            if (Existingmenu== null)
            {
                return NotFound();
            }

            Existingmenu.Title = updatedMenu.Title; 
            Existingmenu.Description = updatedMenu.Description;
           Existingmenu.Price= updatedMenu.Price;   
            Existingmenu.ImageUrl = updatedMenu.ImageUrl;   
            Existingmenu.IsAvailable= updatedMenu.IsAvailable;  


            _unitOfWork.Menu.Update(Existingmenu);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMenu")]
        public async Task<IActionResult> DeleteSingleMenu(int id)
        {

            Menu menu = await _unitOfWork.Menu.GetSingleAsync(u => u.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            _unitOfWork.Menu.Remove(menu);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
