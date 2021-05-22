﻿using Microsoft.AspNetCore.Mvc;
using MongoDBSynopsis.Core.ApplicationService;
using MongoDBSynopsis.Entities;
using System;
using System.Collections.Generic;

namespace MongoDBSynopsis.Controller.Controllers
{
	public class ProductController : ControllerBase
	{
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_productService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                return Ok(_productService.Read(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST api/product
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product value)
        {
            try
            {
                return Ok(_productService.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product value)
        {
            try
            {
                if (id != value.Id)
                {
                    return Conflict("Parameter ID does not match Product id");
                }
                return Ok(_productService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product deletedProduct = _productService.Delete(id);
            if (deletedProduct == null)
            {
                return NotFound($"Did not find Product with ID: {id}");
            }
            return Ok(deletedProduct);
        }
    }
}