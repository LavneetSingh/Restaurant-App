using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class FoodsSearchView : ContentView
    {
        public FoodsSearchView()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
        }
    }
}