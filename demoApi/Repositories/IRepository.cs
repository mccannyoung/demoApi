using demoApi.Models;

namespace demoApi.Repositories
{
    public interface IRepository{
        Product GetProductById(int productId);
        void UpdateProductPrice(Product updatedProduct);
    }    
}
