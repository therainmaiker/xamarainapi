using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ComsumeApi.Models;
using Newtonsoft.Json;

namespace ComsumeApi.Services
{
    class CategoryService
    {
        static readonly string baseUrl = "https://store-app-dd5.conveyor.cloud";
        static readonly string url = $"{baseUrl}/api/Product/";
        private readonly string apiUrl = "https://store-app-dd5.conveyor.cloud/api/Product/";

        private async Task<HttpClient> GetClient()
        {
            //HttpClientHandler clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient();
            //if (string.IsNullOrEmpty(authorizationKey))
            //{
            //    authorizationKey = await client.GetStringAsync(Url + "login");
            //    auth = JsonConvert.DeserializeObject<string>(authorizationKey);
            //}

            //client.DefaultRequestHeaders.Add("Authorization", auth);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            HttpClient client = await GetClient();
            //HttpClient clientt = new HttpClient();
            var result = client.GetStringAsync(url);
            result.Wait();
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(result.Result);
        }

        public async Task<Product> Add(Product product)
        {
            Product addProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Color = product.Color,
                Quantity = product.Quantity,
                LongDescription = product.LongDescription,
                ShortDescription = product.ShortDescription
            };

            HttpClient client = await GetClient();
            var response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(addProduct), Encoding.UTF8, "application/json"));
            //return JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
            return JsonConvert.DeserializeObject<Product>(await response.Result.Content.ReadAsStringAsync());

        }
    }
}
