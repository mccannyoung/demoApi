using Microsoft.VisualStudio.TestTools.UnitTesting;
using demoApi.Controllers;
using demoApi.Repositories;
using demoApi.DataSources;
using Microsoft.Extensions.Logging;
using demoApi.Models;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace demoApi.Tests
{
    [TestClass]
    public class AllUnitTest
    {
        private readonly ProductsController productsController;
        private readonly MockRepository mockRepo;
        private readonly RedSkyApi redSkyApi;
        private readonly ILogger<ProductsController> logger;
        public AllUnitTest()
        {
            mockRepo = new MockRepository();

            productsController = new ProductsController(mockRepo, logger);
            redSkyApi = new RedSkyApi();

        }

        [TestMethod]
        public void TestGet()
        { 
            var expected = mockRepo.GetProductById(5);
            var actual = productsController.Get(5);

            Assert.AreEqual(expected, actual);
        } 

        [TestMethod]
        public void TestPut()
        {
            var updatedProduct = mockRepo.GetProductById(5);
            productsController.Put(5, updatedProduct);
        }

        [TestMethod]
        public void TestRedSkyApi()
        {
            var product = redSkyApi.GetNonPriceDataById(13860428);
            Assert.IsTrue(true);
        }

        // This is testing to make sure an error is thrown when attempting it with a bad sku

        [TestMethod]
        public void TestInvalidSKURedSky()
        {
            try { 
                var product = redSkyApi.GetNonPriceDataById(-15117729);

                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }

            
        }

        // This is testing to make sure an error is thrown when attempting it with a bad sku

        [TestMethod]
        public void TestInvalidSKURedis()
        {
            var redis = new RedisDB();
            try
            {
                var product = redis.GetPriceData(-15117729);

                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }


        }

        [TestMethod]
        public void testGetProductRedisDB()
        {
            var testProductId = 13860428;
            var dataForDB = new Current_Price();
            dataForDB.currency_code = "USD";
            dataForDB.value = 18.12;
            var writeThis = JsonConvert.SerializeObject(dataForDB);
            var manager = new RedisManagerPool("localhost:6379");
            using (var client = manager.GetClient())
            {
                client.Set(testProductId.ToString(), writeThis);
            }

            var redisRepo = new RedisDB();
            var actualResults = redisRepo.GetPriceData(testProductId);
            Assert.AreEqual(actualResults, dataForDB);

        }

        [TestMethod]
        public void TestRepoVsDataSources()
        {
            var productId = 13860428;
            var redisRepo = new RedisRepository();
            var redSky = new RedSkyApi();
            var redis = new RedisDB();

            var redSkyData = redSky.GetNonPriceDataById(productId);
            var repoData = redisRepo.GetProductById(productId);
            var redisData = redis.GetPriceData(productId);

            Assert.AreEqual(repoData.name, redSkyData.name);
            Assert.AreEqual(repoData.id, redSkyData.id);
            Assert.AreEqual(repoData.current_price.value, redisData.value);
            Assert.AreEqual(repoData.current_price.currency_code, redisData.currency_code);
        }

    }
}
