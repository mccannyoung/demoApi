using Microsoft.AspNetCore.Mvc;
using demoApi.Models;
using demoApi.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace demoApi.Controllers
{
   
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public ProductsController(IRepository repo, ILogger<ProductsController> logger){
            _repository = repo;
            _logger = logger;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            try { 
                if (_repository != null)
                {
                    var product = _repository.GetProductById(id);
                    if (product.id == id)
                        return product;
                }
                return new Product();
            }
            catch(Exception ex)
            {
                _logger.LogCritical("Error fetching product information for " + id + " error thrown: " + ex.Message);
                return new Product();
            }

            
        }

        // PUT api/values
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Product updatedProduct)
        {
            try
            {
                _repository.UpdateProductPrice(updatedProduct);
            }catch(Exception ex)
            {
                _logger.LogCritical("Error updating product price for " + id + " to " + updatedProduct.current_price.value + " error thrown: " + ex.Message);
            }
            
        }
    }
}
