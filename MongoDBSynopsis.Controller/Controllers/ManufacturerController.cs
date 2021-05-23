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
                return Ok(_manufacturerService.Update(value));
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
            Manufacturer deletedManufacturer = _manufacturerService.Delete(id);
            if (deletedManufacturer == null)
            {
                return NotFound($"Did not find Manufacturer with ID: {id}");
            }
            return Ok(deletedManufacturer);
        }
    }
}
