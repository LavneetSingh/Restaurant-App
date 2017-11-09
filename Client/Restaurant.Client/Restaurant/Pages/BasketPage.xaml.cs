﻿using System;
using System.Reactive.Linq;
using Restaurant.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : BasketPageXaml
    {
        public BasketPage()
        {
            InitializeComponent();
            Observable.FromEventPattern<SelectedItemChangedEventArgs>(orders, "ItemSelected")
                .Select(x => x.Sender)
                .Cast<ListView>()
                .Subscribe(l => l.SelectedItem = null);
        }

        protected override void OnLoaded()
        {
            BindingContext = ViewModel;
        }
    }

    public abstract class BasketPageXaml : BaseContentPage<BasketViewModel>
    {
    }
}