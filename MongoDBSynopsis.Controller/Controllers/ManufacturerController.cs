using Microsoft.AspNetCore.Mvc;
using MongoDBSynopsis.Core.ApplicationService;
using MongoDBSynopsis.Entities;
using System;
using System.Collections.Generic;

namespace MongoDBSynopsis.Controller.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
	{
        private readonly IManufacturerService _manufacturerService;


        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        // GET manufacturer
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get()
        {
            try
            {
                return Ok(_manufacturerService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET manufacturer/5
        [HttpGet("{id}")]
        public ActionResult<Manufacturer> Get(string id)
        {
            try
            {
                return Ok(_manufacturerService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST manufacturer
        [HttpPost]
        public ActionResult<Manufacturer> Post([FromBody] Manufacturer value)
        {
            try
            {
                return Ok(_manufacturerService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT manufacturer/5
        [HttpPut("{id}")]
        public ActionResult<Manufacturer> Put([FromBody] Manufacturer value)
        {
            try
            {
                bool success = _manufacturerService.Update(value);
                if (!success)
                {
                    return NotFound($"Could not update Manufacturer with ID: {value.Id}");
                }
                return Ok($"Updated Manufacturer with ID: {value.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE manufacturer/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(string id)
        {
			try
			{
                bool success = _manufacturerService.Delete(id);
                if (!success)
                {
                    return NotFound($"Did not find Manufacturer with ID: {id}");
                }
                return Ok($"Deleted Manufacturer with ID: {id}");
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
