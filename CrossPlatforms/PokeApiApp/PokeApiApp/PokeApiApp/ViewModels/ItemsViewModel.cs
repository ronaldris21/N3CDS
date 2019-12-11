using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using PokeApiApp.Models;
using PokeApiApp.Views;
using PokeApiApp.Services;

namespace PokeApiApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private ObservableCollection<Result> _Pokemones;
        private Result _pokeSelected;

        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Result> PokemonsLista
        {
            get => _Pokemones;
            set => SetProperty(ref _Pokemones, value);
        }

        public Result pokeSelected
        {
            get => _pokeSelected;
            set { SetProperty(ref _pokeSelected, value); itemtappedmethod(null); }
        }
        public Command LoadItemsCommand { get; set; }
        public Command ItemTappedCommand { get { return new Command(itemtappedmethod); } }

        

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        private async  void itemtappedmethod(object obj)
        {
            if (pokeSelected!=null)
            {
                var api = new RestClient();
                Pokemondetail pokeselected = new Pokemondetail();
                Task.Run(async () =>
                    pokeselected = await api.PokemondetailMethod(pokeSelected.url)
                       ).Wait();
                var viewmodel = new pokemonViewModewl(pokeselected);
                var vista = new Pokemon();
                vista.BindingContext = viewmodel;
                await App.Current.MainPage.Navigation.PushAsync(vista);
                pokeselected = null;
            }

        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                var api = new RestClient();
                Pokemons data = new Pokemons();
                Task.Run(async () =>
                     data = await api.GetPokemons(300)
                   ).Wait();

                try
                {
                    PokemonsLista = new ObservableCollection<Result>(data.results);
                }
                catch (Exception)
                {
                    PokemonsLista = new ObservableCollection<Result>();
                }


                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}