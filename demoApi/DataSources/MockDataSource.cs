using demoApi.Models;

namespace demoApi.DataSources
{
    public class MockDataSource : IDataSource
    {
        public Product GetNonPriceDataById(int productId)
        {
            var product = new Product();
            product.id = 7;
            product.name = "Mock";

            return product;
        }

        public Current_Price GetPriceData(int productId)
        {
            var currentPrice = new Current_Price();
            currentPrice.currency_code = "USD";
            currentPrice.value = 14.92;
            return currentPrice;
        }

        public void UpdatePriceData(int id, Current_Price current_price)
        {
            return;
        }
    }
}
