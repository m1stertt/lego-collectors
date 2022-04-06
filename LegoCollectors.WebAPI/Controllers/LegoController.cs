using System;
using System.Collections.Generic;
using System.IO;
using LegoCollectors.Core.IServices;
using LegoCollectors.Core.Models;
using LegoCollectors.Security.Model;
using Microsoft.AspNetCore.Mvc;

namespace lego_collectors.Controllers
{
    [Route("api/[controller]")]
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
            Console.WriteLine("Test");
            if (HttpContext.Items["LoginUser"] is not LoginUser user) return Unauthorized();
            return Ok(_legoService.GetLegos(user.Id));
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
            Console.WriteLine("HELLO WORLD");
            Console.WriteLine(lego);
            if (lego == null)
            {
                return BadRequest("A lego is required before creating a lego in the repository.");
            }
            if (HttpContext.Items["LoginUser"] is not LoginUser user) return Unauthorized();
            lego.OwnerId = user.Id;
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