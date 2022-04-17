using System;
using Newtonsoft.Json;

namespace Restaurant.Abstractions.DataTransferObjects
{
    public class FoodDto
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("price")] public decimal Price { get; set; }

    }
}