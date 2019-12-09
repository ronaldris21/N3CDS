

namespace MasterYUGIOHAppFinal.Views
{

    using Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();
        MenuItemType TypePrevio;
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //Defino el Detail
            Detail = new NavigationPage(new ItemsPage());

            MenuPages.Add(MenuItemType.link_monster_cards, (NavigationPage)Detail);
            TypePrevio = MenuItemType.link_monster_cards;
        }


        protected  override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(

                async () =>
                {
                    if (MenuPages[TypePrevio].Navigation.NavigationStack.Count > 1)
                    {
                        await MenuPages[TypePrevio].Navigation.PopAsync();
                        Detail = MenuPages[TypePrevio];
                        if (Device.RuntimePlatform == Device.Android)
                            await Task.Delay(100);
                    }
                    else
                    {
                        //DisplayAlter
                        bool permanecer = await App.Current.MainPage.DisplayAlert("Saliendo", "Estas a punto de cerrar el app", "Permanecer", "Cerrar");
                        if (permanecer==false)
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                    }
                }
            );
            return true;//Para permanecer
        }
        public int RisCurrentStackPagesCount()
        {
            return MenuPages[TypePrevio].Navigation.NavigationStack.Count;
        }

        public async Task RisPushPage(Page pagina)
        {
            await MenuPages[TypePrevio].Navigation.PushAsync(pagina);
            Detail = MenuPages[TypePrevio];
            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(100);
        }

        public async Task NavigateFromMenu(MenuItemType id)
        {

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItemType.monster_cards:
                        break;
                    case MenuItemType.ritual_monster_cards:
                        break;
                    case MenuItemType.link_monster_cards:
                        break;
                    case MenuItemType.synchro_monster_cards:
                        break;
                    case MenuItemType.xyz_monster_cards:
                        break;
                    case MenuItemType.pendulum_monster_cards:
                        break;
                    case MenuItemType.spell_cards:
                        break;
                    case MenuItemType.trap_cards:
                        break;
                    default:
                        break;
                }

                //Ahorita solo lo agrego una vez porque reusare la vista!
                MenuPages.Add(id, new NavigationPage(new ItemsPage(id)));
            }
            else
            {
                //Guardo el estado previor de la pagina
                MenuPages[TypePrevio] = (NavigationPage)Detail;
            }




            if (MenuPages[id] != null && Detail != MenuPages[id])
            {

                Detail = MenuPages[id];
                TypePrevio = id;
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}