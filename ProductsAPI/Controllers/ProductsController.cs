using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductRepo _repo;

        public ProductsController(ProductRepo repo)
        {
            _repo = repo;
        }

        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repo.GetProducts();
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product.Name == null || product.Price <= 0)
            {
                return BadRequest();
            }

            _repo.AddProduct(product);
            return Created(nameof(Get), product);
        }
    }
}
