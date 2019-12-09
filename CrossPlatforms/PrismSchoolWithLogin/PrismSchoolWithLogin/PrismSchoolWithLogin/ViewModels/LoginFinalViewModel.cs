using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace PrismSchoolWithLogin.ViewModels
{
    public class LoginFinalViewModel : ViewModels.ViewModelBase
    {

        private bool _isNotBusy;
        public bool IsNotBusy
        {
            get { return _isNotBusy; }
            set { SetProperty(ref _isNotBusy, value); IsBusy = !IsNotBusy; }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); IsNotBusy = !IsBusy; }
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
        public LoginFinalViewModel(INavigationService nav) : base(nav)
        {
            IsBusy = false;
        }

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

            if (Pass != "1234")
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Contraseña incorrecta",
                    "Ok");
                IsBusy = false;
                return;
            }
            if (Correo != "Admin01")
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario incorrecto",
                    "Ok");
                IsBusy = false;
                return;
            }


            await NavigationService.NavigateAsync("/NavigationPage/" + nameof(Views.MainPage));  //  "/" Para que lo pnga como pprincipal

            IsBusy = false;
            Correo = string.Empty;
            Pass = string.Empty;
        }

    }

}
