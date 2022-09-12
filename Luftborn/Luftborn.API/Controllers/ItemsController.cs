using Luftborn.API.BLL.Items;
using Luftborn.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class ItemsController : ControllerBase
    {
        private readonly IitemBLL _itemRepo; 
        public ItemsController(IitemBLL itemRepo)
        {
            _itemRepo = itemRepo;
        }
       
        [HttpGet]
        public IActionResult GetItems()
        {
            try
            {
                List<Item> itemList = _itemRepo.GetAll().ToList();
                return Ok(itemList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
          
        }
        [HttpGet]
        public IActionResult GetOneItem(int id)
        {
            try
            {
                Item item = _itemRepo.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        public async Task<IActionResult> SaveItem(Item item)
        {
            try
            {
                int res = await _itemRepo.SaveItem(item);
               if (res == 1) 
                return Ok();
               else
                    return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            try
            {
                int res = await _itemRepo.Delete(itemId);
                if (res == 1)
                    return Ok();
                else
                    return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
