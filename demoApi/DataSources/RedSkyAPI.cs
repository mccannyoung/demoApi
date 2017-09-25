using System;
using demoApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;

namespace demoApi.DataSources
{
    public class RedSkyApi : IDataSource
    {
       
        public Product GetNonPriceDataById(int productId)
        {
            var product = new Product();
            var path = "http://redsky.target.com/v2/pdp/tcin/" + productId + "?excludes=taxonomy,price,promotion,bulk_ship,deep_red_labels,available_to_promise_network,rating_and_review_reviews,rating_and_review_statistics,question_answer_statistics,tax_category,display_option,fulfillment,package_dimensions";
            RedSkyDataReturnModels.RootObject returnedProduct;
            try
            { 
                using (HttpClient client = new HttpClient()) {

                    HttpWebRequest request = this.GetRequest(path);
                    WebResponse response = request.GetResponse();

                    var responseText = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    returnedProduct = JsonConvert.DeserializeObject<RedSkyDataReturnModels.RootObject>(responseText);
                }

                product.id = productId;
                product.name = returnedProduct.product.item.product_description.general_description;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }

        public Current_Price GetPriceData(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePriceData(int id, Current_Price current_price)
        {
            throw new NotImplementedException();
        }

        private HttpWebRequest GetRequest(string url, string httpMethod = "GET", bool allowAutoRedirect = true)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";

            request.Timeout = Convert.ToInt32(new TimeSpan(0, 5, 0).TotalMilliseconds);
            request.Method = httpMethod;
            return request;
        }
    }
}
