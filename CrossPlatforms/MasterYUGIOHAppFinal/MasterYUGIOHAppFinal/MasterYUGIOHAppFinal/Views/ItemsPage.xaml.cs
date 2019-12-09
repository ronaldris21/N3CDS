
namespace MasterYUGIOHAppFinal.Views
{

    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Models;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel();
        }

        public ItemsPage(MenuItemType type)
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel(type);
        }

        private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await ((Views.MainPage)App.Current.MainPage).RisPushPage(new PagePruebasNavigation(
                    ((Views.MainPage)App.Current.MainPage).RisCurrentStackPagesCount()
                ));

        }
    }
}