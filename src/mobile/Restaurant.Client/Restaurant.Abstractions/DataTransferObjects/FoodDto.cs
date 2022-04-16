using System;
using Newtonsoft.Json;

namespace Restaurant.Abstractions.DataTransferObjects
{
    public class FoodDto
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("picture")] public string Picture { get; set; }
        [JsonProperty("price")] public decimal Price { get; set; }

        [JsonProperty("cuisine")] public string Cuisine { get; set; }


    }
}