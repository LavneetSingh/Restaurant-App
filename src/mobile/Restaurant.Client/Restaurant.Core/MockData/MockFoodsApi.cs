using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Restaurant.Abstractions.Api;
using Restaurant.Abstractions.DataTransferObjects;

namespace Restaurant.Core.MockData
{
    [ExcludeFromCodeCoverage]
    public class MockFoodsApi : IFoodsApi
    {
        public async Task<IEnumerable<FoodDto>> GetFoods(int count = 10, int skip = 0)
        {
            const string baseUrl = "https://rmvrvmbackend.azurewebsites.net/api/Restaurant/";

            HttpClient httpClient = new HttpClient();
            var uri = new Uri(baseUrl + "GetMenu/");
            var resp = await httpClient.GetAsync(uri);

            return ParseRestaurantMenu(await resp.Content.ReadAsStringAsync()) as IEnumerable<FoodDto>;
        }

        public Task<FoodDto> GetFood(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Create(FoodDto food)
        {
            throw new NotImplementedException();
        }

        public Task UploadFile(Stream file, string foodId)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, FoodDto food)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        List<FoodDto> ParseRestaurantMenu(string restaurantMenuJSON)
        {
            var json = restaurantMenuJSON.Replace("\"",string.Empty).Replace("\\u0022", "\"");
            JObject data = JObject.Parse(json);
            List<FoodDto> menu = new List<FoodDto>();

            foreach (var item in data["categorys"])
            {
                foreach (var menuItem in item["menu-items"])
                {
                    var foodItem = new FoodDto()
                    {
                        Id = menuItem["id"].Value<int>(),
                        Name = menuItem["name"].Value<string>(),
                        Description = menuItem["description"].Value<string>(),
                        Price = menuItem["sub-items"][0]["price"].Value<Decimal>(),
                        Cuisine = menuItem["sub-items"][0]["cuisine_name"].Value<string>()
                    };
                   foodItem.Price /= (decimal)70.0;
                    
                    menu.Add(foodItem);
                }
            }

            return menu;
        }

    }
}