using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterYUGIOHAppFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePruebasNavigation : ContentPage
    {
        public PagePruebasNavigation(int NumPaginaStack)
        {
            InitializeComponent();
            txtCant.Text = $"{NumPaginaStack} Paginas";
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await((Views.MainPage)App.Current.MainPage).RisPushPage(new PagePruebasNavigation(
                    ((Views.MainPage)App.Current.MainPage).RisCurrentStackPagesCount()
                ));

        }
    }
}