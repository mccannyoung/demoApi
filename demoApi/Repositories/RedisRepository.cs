using demoApi.Models;
using demoApi.DataSources;
using System;

namespace demoApi.Repositories{
    public class RedisRepository:IRepository{

        private readonly IDataSource redSkyDataSource = new RedSkyApi() ;
        private readonly IDataSource redisDB = new RedisDB();

        public Product GetProductById(int productId){

            var returnProduct = redSkyDataSource.GetNonPriceDataById(productId);

            if (returnProduct.id != productId)
                throw new Exception("Could not retrieve product information for " + productId);
            returnProduct.current_price = redisDB.GetPriceData(productId);

            if (returnProduct.current_price.value >= 0)
                return returnProduct;
            throw new Exception("Could not retrieve product information for " + productId);
        }

        public void UpdateProductPrice(Product updatedProduct){
            var currentProduct = GetProductById(updatedProduct.id);

            // validate that the data is expected and sane
            if (updatedProduct.current_price.value >= 0
                && updatedProduct.name == currentProduct.name)
                redisDB.UpdatePriceData(updatedProduct.id, updatedProduct.current_price);
            else
                throw new Exception("Invalid input");
        }
    }
}
