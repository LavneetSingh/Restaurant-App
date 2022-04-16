using System;
using Restaurant.Abstractions.DataTransferObjects;

namespace Restaurant.Abstractions.ViewModels
{
    public interface IFoodViewModel : INavigatableViewModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Picture { get; set; }
        decimal Price { get; set; }
        bool IsFavorite { get; set; }
    }
}