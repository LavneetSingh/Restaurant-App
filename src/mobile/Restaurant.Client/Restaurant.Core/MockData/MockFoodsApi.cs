using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Restaurant.Abstractions.Api;
using Restaurant.Abstractions.DataTransferObjects;
using Restaurant.Abstractions.ViewModels;

namespace Restaurant.Core.MockData
{
    [ExcludeFromCodeCoverage]
    public class MockFoodsApi : IFoodsApi
    {
        public async Task<IEnumerable<FoodDto>> GetFoods(int count = 10, int skip = 0)
        {
            const string baseUrl = "https://rmvrvmbackend.azurewebsites.net/api/Restaurant/";

            HttpClient httpClient = new HttpClient();
            var uri = new Uri(baseUrl + "GetrMVrVMMenu/");
            var resp = await httpClient.GetAsync(uri);
            var menu = JsonConvert.DeserializeObject<List<FoodDto>>(await resp.Content.ReadAsStringAsync());

            return (IEnumerable<FoodDto>)menu;
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
    }
}