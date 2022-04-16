using System;
using System.Windows.Input;
using ReactiveUI;
using Restaurant.Abstractions.DataTransferObjects;
using Restaurant.Abstractions.ViewModels;

namespace Restaurant.Core.ViewModels.Food
{
    public class FoodViewModel : BaseViewModel, IFoodViewModel
    {
        public FoodViewModel()
        {
            FavoriteCommand = ReactiveCommand.Create(() =>
            {
                IsFavorite = !IsFavorite;
            });
        }
        private int _id;
        private string _name;
        private string _description;
        private string _picture;
        private decimal _price;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Picture
        {
            get => _picture;
            set => _picture = value;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set => this.RaiseAndSetIfChanged(ref _isFavorite, value);
        }
        
        public FoodViewModel Clone()
        {
            return (FoodViewModel)MemberwiseClone();
        }
        
        public ICommand FavoriteCommand { get; }
    }
}