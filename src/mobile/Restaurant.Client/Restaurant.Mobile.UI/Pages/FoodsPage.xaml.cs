using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Restaurant.Core.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class FoodsPage : FoodsXamlPage
    {
        public FoodsPage()
        {
            InitializeComponent();
            //FoodsList.SelectionChanged += (s, e) => { FoodsList.SelectedItem = null; };
        }

        protected override async void OnLoaded()
        {
            lastBatteryLevel = Battery.ChargeLevel * 100.0;
            experimentStartTime = DateTime.Now;
            consumptionReport.Add(new Tuple<string, string>("Mode", "MVVM"));
            base.OnLoaded();
            await ViewModel.LoadFoods();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            base.OnLoaded();
            await ViewModel.LoadFoods();
            TakeBatteryReading();
        }
        private async Task SaveReport()
        {
            HttpClient httpClient = new HttpClient();
            var uri = new Uri(baseUrl + consumptionReportUrl);
            var content = new StringContent(JsonConvert.SerializeObject(consumptionReport), Encoding.UTF8, "application/json");
            await httpClient.PostAsync(uri, content);
        }
        private void TakeBatteryReading()
        {
            var curCharge = Battery.ChargeLevel * 100.0;
            if (curCharge < lastBatteryLevel)
            {
                var duration = (DateTime.Now - experimentStartTime).ToString(@"hh\:mm\:ss");

                consumptionReport.Add(new Tuple<string, string>(duration, curCharge.ToString("F")));

                lastBatteryLevel = curCharge;
            }
        }
        DateTime experimentStartTime;
        double lastBatteryLevel;
        private readonly List<Tuple<string, string>> consumptionReport = new List<Tuple<string, string>>();
        const string consumptionReportUrl = "uploadconsumptioneport";
        const string baseUrl = "https://rmvrvmbackend.azurewebsites.net/api/CPUIntensiveTasks/";

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await SaveReport();
        }
    }

    public abstract class FoodsXamlPage : BaseContentPage<FoodsViewModel>
    {
    }
}