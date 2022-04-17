using System;
using Newtonsoft.Json;
using Restaurant.Abstractions.DataTransferObjects;

namespace Restaurant.Abstractions.ViewModels
{
    public interface IFoodViewModel : INavigatableViewModel
    {
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        bool IsFavorite { get; set; }
    }
}