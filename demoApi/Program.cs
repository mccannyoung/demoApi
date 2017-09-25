using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceStack.Redis;
using demoApi.Models;
using Newtonsoft.Json;
using System;

namespace demoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // this code should be taken out for production
            // but since this is a coding challenge, this seemed
            // to be the easiest way to get the data in the DB
            var dataForDB = new Current_Price();
            dataForDB.currency_code = "USD";
            dataForDB.value = 18.12;
            var writeThis = JsonConvert.SerializeObject(dataForDB);
            var manager = new RedisManagerPool(Environment.GetEnvironmentVariable("redis_ip") + ":" + Environment.GetEnvironmentVariable("redis_port"));
            using (var client = manager.GetClient())
            {
                client.Set("13860428",writeThis);
            }
                BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();
    }
}
