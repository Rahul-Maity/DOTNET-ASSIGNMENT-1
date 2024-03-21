using DOTNET_ASSIGNMENT_1.Models;
using DOTNET_ASSIGNMENT_1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_ASSIGNMENT_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemReository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemReository = itemRepository;
        }
        [HttpGet("{key}")]
        public async Task<IActionResult>Get(string key)
        {
            try
            {
                var item = await _itemReository.GetByIdAsync(key);
                return Ok(item);
            }
            catch (NotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> Post([FromBody]Item item)
        {
            try
            {
                await _itemReository.AddorUdateAsync(item.key, item.value);
                return Ok(item);
            }
            catch (ConflictExcetion ex) {
                return Conflict(ex.Message);
            }
        }
        [HttpPatch("{key}/{value}")]
        public async Task<IActionResult>Patch(string key,string value)
        {
            try
            {
              await _itemReository.UpdateAsync(key, value);
                return Ok();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult>Delete(string key)
        {
            try
            {
                await _itemReository.DeleteAsync(key);
                return Ok();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
