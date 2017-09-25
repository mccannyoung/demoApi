using System;
using demoApi.Models;

namespace demoApi.Repositories{

    public class MockRepository:IRepository{
        public Product GetProductById(int productId) {
            var product2Return = new Product
            {
                name = "TestProd",
                id = productId
            };
            var current_Price = new Current_Price
            {
                value = 7,
                currency_code = "USD"
            };
            return product2Return;
        }

        public void UpdateProductPrice(Product updatedProduct){
            var current_Product = GetProductById(updatedProduct.id);
            if (current_Product.id == updatedProduct.id &&
                current_Product.name == updatedProduct.name &&
                current_Product.current_price.currency_code == updatedProduct.current_price.currency_code){
                    return;
                }
            throw new Exception("Could not modify price.");
        }
    }
}
