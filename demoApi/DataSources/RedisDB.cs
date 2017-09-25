using System;
using demoApi.Models;
using ServiceStack.Redis;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace demoApi.DataSources
{
    public class RedisDB : IDataSource
    {

        public Product GetNonPriceDataById(int productId)
        {
            throw new NotImplementedException();
        }

        public Current_Price GetPriceData(int productId)
        {
            var currentPrice = new Current_Price();

            try
            {
                var manager = new RedisManagerPool(Environment.GetEnvironmentVariable("redis_ip")+":"+ Environment.GetEnvironmentVariable("redis_port"));
                using (var client = manager.GetClient())
                {
                    var returnedData = client.Get<string>(productId.ToString());
                    currentPrice = JsonConvert.DeserializeObject<Current_Price>(returnedData);
                }
            }
            catch
            {
                currentPrice = new Current_Price
                {
                    value = -1
                };
            }

            return currentPrice;
        }

        public void UpdatePriceData(int id, Current_Price currentPrice)
        {
            try { 
                var serializedDataToWrite = JsonConvert.SerializeObject(currentPrice);
                var manager = new RedisManagerPool(Environment.GetEnvironmentVariable("redis_ip") + ":" + Environment.GetEnvironmentVariable("redis_port"));
                using (var client = manager.GetClient())
                {
                    client.Set(id.ToString(), serializedDataToWrite);
                }
            }catch(Exception ex)
            {
                throw ex;
            }

        }

    }
}
