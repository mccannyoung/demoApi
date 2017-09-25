using Microsoft.AspNetCore.Mvc;
using demoApi.Models;
using demoApi.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

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
                throw new Exception("Could not connect to data source");
            }
            catch (NullReferenceException)
            {
                HttpContext.Response.StatusCode = 404;
                return new Product();
            }
            catch (WebException we)
            {
                HttpWebResponse res = (HttpWebResponse)we.Response;
                HttpContext.Response.StatusCode = (int)res.StatusCode;
                return new Product();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error fetching product information for " + id + " error thrown: " + ex.Message);
                throw ex;
            }

        }

        // PUT api/values
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Product updatedProduct)
        {
            try
            {
                _repository.UpdateProductPrice(updatedProduct);
            }
            catch (NullReferenceException)
            {
                HttpContext.Response.StatusCode = 404;
            }
            catch (WebException we)
            {
                HttpWebResponse res = (HttpWebResponse)we.Response;
                HttpContext.Response.StatusCode = (int)res.StatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error updating product price for " + id + " to " + updatedProduct.current_price.value + " error thrown: " + ex.Message);
                throw ex;
            }
            
        }
    }
}
