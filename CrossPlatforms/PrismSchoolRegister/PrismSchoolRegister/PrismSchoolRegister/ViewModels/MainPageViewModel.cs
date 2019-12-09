namespace PrismSchoolRegister.ViewModels
{

    using Prism.Commands;
    using Prism.Navigation;
    using System;
    using System.Threading.Tasks;

    public class MainPageViewModel : Prism.Mvvm.BindableBase
    {
        int cantLogin = 1;
        public INavigationService NavigationService { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Title = "Login";
            IsNotBusy = true;
        }
        public MainPageViewModel()
        {
            IsBusy = false;
            Title = "LOGIN";
        }
        private string _Tittle;
        public string Title
        {
            get { return _Tittle; }
            set { SetProperty(ref _Tittle, value); }
        }
        private bool _isNotBusy;
        public bool IsNotBusy
        {
            get { return _isNotBusy; }
            set 
            {
                if (SetProperty(ref _isNotBusy, value))
                    IsBusy = !IsNotBusy;
            }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set 
            {
                if (SetProperty(ref _IsBusy, value))
                    IsNotBusy = !IsBusy;
            }
        }

        #region Propiedades
        private string _correo;
        public string Correo
        {
            get { return _correo; }
            set { SetProperty(ref _correo, value); }
        }
        private string _pass;
        public string Pass
        {
            get { return _pass; }
            set { SetProperty(ref _pass, value); }
        }
        #endregion


        #region Commands
        private DelegateCommand _LoginCommand;
        public DelegateCommand LoginCommand { get => _LoginCommand == null ? _LoginCommand = new DelegateCommand(LoginMehtod) : _LoginCommand; }
        #endregion

        private async void LoginMehtod()
        {
            IsBusy = true;
            await Task.Delay(200);
            if (string.IsNullOrEmpty(Correo))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese su correo electronico",
                    "Ok");
                IsBusy = false;
                return;
            }
            if (string.IsNullOrEmpty(Pass))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese su contraseña",
                    "Ok");
                IsBusy = false;
                return;
            }

            
            if (Correo != "Ris")
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario incorrecto",
                    "Ok");
                IsBusy = false;
                cantLogin++; CheckCOUNT();
                return;
            }
            if (Pass != "123")
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Contraseña incorrecta",
                    "Ok");
                IsBusy = false;
                cantLogin++; CheckCOUNT();
                return;
            }


            await NavigationService.NavigateAsync("/NavigationPage/Menu");  //  "/" Para que lo pnga como pprincipal

            IsBusy = false;
            Correo = string.Empty;
            Pass = string.Empty;
        }

        private void CheckCOUNT()
        {
            if (cantLogin>3)
            {
                App.Current.MainPage.DisplayAlert("Intentos sospechosos", "Has intentado loguearte demasidas veces erroneamente", "Ok");
            }
        }
    }
}
