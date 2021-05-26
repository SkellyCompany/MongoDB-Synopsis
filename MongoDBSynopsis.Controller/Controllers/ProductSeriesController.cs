using Microsoft.AspNetCore.Mvc;
using MongoDBSynopsis.Core.ApplicationService;
using MongoDBSynopsis.Entities;
using System;
using System.Collections.Generic;

namespace MongoDBSynopsis.Controller.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductSeriesController : ControllerBase
	{
        private readonly IProductSeriesService _productSeriesService;


        public ProductSeriesController(IProductSeriesService productSeriesService)
        {
            _productSeriesService = productSeriesService;
        }

        // GET productSeries
        [HttpGet]
        public ActionResult<IEnumerable<ProductSeries>> Get()
        {
            try
            {
                return Ok(_productSeriesService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET productSeries/5
        [HttpGet("{id}")]
        public ActionResult<ProductSeries> Get(string id)
        {
            try
            {
                return Ok(_productSeriesService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET productSeries/5
        [HttpGet("manufacturerId/{id}")]
        public ActionResult<IEnumerable<ProductSeries>> GetByManufacturer(string id)
        {
            try
            {
                return Ok(_productSeriesService.ReadAllByManufacturer(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST productSeries
        [HttpPost]
        public ActionResult<ProductSeries> Post([FromBody] ProductSeries value)
        {
            try
            {
                return Ok(_productSeriesService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT productSeries/5
        [HttpPut("{id}")]
        public ActionResult<ProductSeries> Put(string id, [FromBody] ProductSeries value)
        {
            try
            {
                bool success = _productSeriesService.Update(value);
                if (!success)
                {
                    return NotFound($"Could not update ProductSeries with ID: {value.Id}");
                }
                return Ok($"Updated Product with ID: {value.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE productSeries/5
        [HttpDelete("{id}")]
        public ActionResult<ProductSeries> Delete(string id)
        {
            try
            {
                bool success = _productSeriesService.Delete(id);
                if (!success)
                {
                    return NotFound($"Did not find ProductSeries with ID: {id}");
                }
                return Ok($"Deleted ProductSeries with ID: {id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}