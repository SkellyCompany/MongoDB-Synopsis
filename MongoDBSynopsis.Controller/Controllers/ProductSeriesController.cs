using Microsoft.AspNetCore.Mvc;
using MongoDBSynopsis.Core.ApplicationService;
using MongoDBSynopsis.Entities;
using System;
using System.Collections.Generic;

namespace MongoDBSynopsis.Controller.Controllers
{
	public class ProductSeriesController : ControllerBase
	{
        private readonly IProductSeriesService _productSeriesService;


        public ProductSeriesController(IProductSeriesService productSeriesService)
        {
            _productSeriesService = productSeriesService;
        }

        // GET api/productSeries
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

        // GET api/productSeries/5
        [HttpGet("{id}")]
        public ActionResult<ProductSeries> Get(int id)
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


        // POST api/productSeries
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

        // PUT api/productSeries/5
        [HttpPut("{id}")]
        public ActionResult<ProductSeries> Put(int id, [FromBody] ProductSeries value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match ProductSeries id");
                }
                return Ok(_productSeriesService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/productSeries/5
        [HttpDelete("{id}")]
        public ActionResult<ProductSeries> Delete(int id)
        {
            ProductSeries deletedProductSeries = _productSeriesService.Delete(id);
            if (deletedProductSeries == null)
            {
                return NotFound($"Did not find ProductSeries with ID: {id}");
            }
            return Ok(deletedProductSeries);
        }
    }
}