

namespace MasterYUGIOHAppFinal.Views
{

    using Models;
    using System.ComponentModel;
    using Xamarin.Forms;
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await RootPage.NavigateFromMenu(((MasterMenuItem)e.SelectedItem).Type);
            ((ListView)sender).SelectedItem = null;
        }
    }
}