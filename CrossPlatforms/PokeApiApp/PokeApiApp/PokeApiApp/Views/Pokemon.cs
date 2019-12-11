using System;

using Xamarin.Forms;

namespace PokeApiApp.Views
{
    public class Pokemon : ContentPage
    {
        public Pokemon()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

