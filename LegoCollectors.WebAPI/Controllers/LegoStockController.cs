using System.IO;
using LegoCollectors.Core.IServices;
using LegoCollectors.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace lego_collectors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegoStockController : ControllerBase
    {
        private readonly ILegoStockService _legoStockService;
        
        public LegoStockController(ILegoStockService legoStockService)
        {
            _legoStockService = legoStockService ?? throw new InvalidDataException("LegoStockService Cannot Be Null.");
        }
        
        [HttpPost]  
        public ActionResult<LegoStock> Post([FromBody] LegoStock invStock)
        {
            if (invStock == null)
            {
                return BadRequest("A lego stock is required before creating a lego stock in the repository.");
            }
            
            return Ok(_legoStockService.Create(invStock));
        }
        
        [HttpGet("{id:int}")]
        public ActionResult<LegoStock> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to find a lego stock by it's ID in the repository.");
            }
            return Ok(_legoStockService.FindById(id));
        }
        
        [HttpGet("Product/{id:int}")]
        public ActionResult<LegoStock> GetByUserId(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to find a lego stock by it's ID in the repository.");
            }
            return Ok(_legoStockService.FindByUserId(id));
        }

        [HttpPut("{id}")]  
        public ActionResult<LegoStock> Update(int id, [FromBody] LegoStock invStock)
        {
            if (id < 1 || id != invStock.Id)
            {
                return BadRequest("Correct id is needed to update a lego stock in the repository.");
            }

            return Ok(_legoStockService.Update(invStock));
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult<LegoStock> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to delete by id.");
            }
            return Ok(_legoStockService.DeleteById(id));
        }
    }
}