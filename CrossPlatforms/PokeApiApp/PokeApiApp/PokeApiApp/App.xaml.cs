using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApiApp.Services;
using PokeApiApp.Views;
using DLToolkit.Forms.Controls;

namespace PokeApiApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            FlowListView.Init();
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new ItemsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
