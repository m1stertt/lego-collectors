using System.Collections.Generic;
using System.IO;
using LegoCollectors.Core.IServices;
using LegoCollectors.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lego_collectors.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class LegoController: ControllerBase
    {
    
        private readonly ILegoService _legoService;
        
        public LegoController(ILegoService legoService)
        {
            _legoService = legoService ?? throw new InvalidDataException("LegoService Cannot Be Null.");
        }
        
        [HttpGet]
        public ActionResult<List<Lego>> GetAll()
        {
            return Ok(_legoService.GetLegos());
        }
        
        
        [HttpGet("{id:int}")]
        public ActionResult<Lego> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to find a lego by it's ID in the repository.");
            }
            return Ok(_legoService.GetLegoById(id));
        }
        
        [HttpPost]  
        public ActionResult<Lego> Post([FromBody] Lego lego)
        {
            if (lego == null)
            {
                return BadRequest("A lego is required before creating a lego in the repository.");
            }
            
            return Ok(_legoService.Create(lego));
        }
        
        [HttpPut("{id}")]  
        public ActionResult<Lego> Update(int id, [FromBody] Lego lego)
        {
            if (id < 1 || id != lego.Id)
            {
                return BadRequest("Correct id is needed to update a lego in the repository.");
            }

            return Ok(_legoService.Update(lego));
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult<Lego> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest("An ID is required to delete by id.");
            }
            return Ok(_legoService.DeleteById(id));
        }
    }
}