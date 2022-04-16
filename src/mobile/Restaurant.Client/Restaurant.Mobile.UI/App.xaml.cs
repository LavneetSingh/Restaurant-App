using Autofac;
using Restaurant.Abstractions.Factories;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core;
using Restaurant.Core.Mappers;
using Restaurant.Core.ViewModels;
using Restaurant.Mobile.UI.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        private readonly IPlatformInitializer _platformInitializer;

        public App(IPlatformInitializer platformInitializer)
        {
            _platformInitializer = platformInitializer;
            InitializeComponent();
            SetupMainPage();
        }

        private void SetupMainPage()
        {
            var container = _platformInitializer.Build();
            var viewFactory = container.Resolve<IViewFactory>();
            var welcomePage = viewFactory.ResolveView<IWelcomeViewModel>() as Page;
            var foodsPage = viewFactory.ResolveView<FoodsViewModel>() as Page;

            MainPage = new CustomNavigationPage(foodsPage);
        }

        public new static App Current => (App)Application.Current;

        protected override void OnStart()
        {
            base.OnStart();

        }
    }
}