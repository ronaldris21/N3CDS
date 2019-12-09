using MasterYUGIOHAppFinal.Models;
using MasterYUGIOHAppFinal.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterYUGIOHAppFinal.ViewModels
{
    using MasterYUGIOHAppFinal.Patterns;
    using Models;
    using System.Collections.ObjectModel;

    public class ItemsViewModel : MvvmHelpers.BaseViewModel
    {
        private MenuItemType PageItemType;
        public ObservableCollection<card_data_sets> Cartas { get; set; }
        public Command LoadItemsCommand { get => new Command(() => Task.Run(()=>ExecuteLoadItemsCommand()).Wait()); }

        public ItemsViewModel()
        {
            IsBusy = true;
            PageItemType = MenuItemType.link_monster_cards;
            Title = MenuItemType.link_monster_cards.ToString();
            //Cargo los datos del Json, primer tanda!
            var jsonHandler = new JsonLocalHandler();
            Cartas = new ObservableCollection<card_data_sets>();

            //Singleton

            Task.Run(async () =>
                Singleton.Instance.AllData = await jsonHandler.ReadFromJsonEmbededFile<AllCardsData>(JsonFilePath.Embeded_FileName).ConfigureAwait(false)
            ).Wait();
            //Aqui cargo los datos la primera vez!!!
            IsBusy = false;
            ExecuteLoadItemsCommand();
        }
        public ItemsViewModel(MenuItemType itemType)
        {
            PageItemType = itemType;
            Title = itemType.ToString();
            ExecuteLoadItemsCommand();

        }

        void ExecuteLoadItemsCommand()
        {

               if (IsBusy)
                   return;

               IsBusy = true;

               try
               {
                   int cantidadCartas = 15;
                   //Aqui halo los datos que requiero
                   switch (PageItemType)
                   {
                       case MenuItemType.monster_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.monster_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.ritual_monster_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.ritual_monster_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.link_monster_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.link_monster_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.synchro_monster_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.synchro_monster_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.xyz_monster_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.xyz_monster_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.pendulum_monster_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.pendulum_monster_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.spell_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.spell_cards.GetRange(0, cantidadCartas));
                           break;
                       case MenuItemType.trap_cards:
                           Cartas = new ObservableCollection<card_data_sets>(Singleton.Instance.AllData.trap_cards.GetRange(0, cantidadCartas));
                           break;
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