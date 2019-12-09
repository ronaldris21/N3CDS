

namespace PrismSchoolRegister.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Navigation;
    public class MenuViewModel : BindableBase
    {
        private string _Tittle;
        public string Title
        {
            get { return _Tittle; }
            set { SetProperty(ref _Tittle, value); }
        }
        public INavigationService Nav { get; set; }
        public MenuViewModel(INavigationService navigationService)
        {
            Title = "Main Page";
            Nav = navigationService;
        }

        #region Commands
        public DelegateCommand DocentesCommand { get => new DelegateCommand(() => DocentesNavigationMethod(null)); }

        private async void DocentesNavigationMethod(object obj)
        {
            await Nav.NavigateAsync("/NavigationPage/Menu");
        }
        #endregion
    }
}



