using demoApi.Models;

namespace demoApi.DataSources
{
    public interface IDataSource
    {
        Current_Price GetPriceData(int productId);
        void UpdatePriceData(int id, Current_Price current_price);
        Product GetNonPriceDataById(int productId);

    }
}
