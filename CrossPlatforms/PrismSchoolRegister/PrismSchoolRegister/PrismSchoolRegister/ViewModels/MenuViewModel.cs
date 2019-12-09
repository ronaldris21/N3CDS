

namespace PrismSchoolRegister.ViewModels
{
    using System;
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
        public DelegateCommand DocentesCommand { get => new DelegateCommand(() => DocentesNavigationMethod()); }
        public DelegateCommand MateriasCommand { get => new DelegateCommand(() => MateriasNavigationMethod()); }

        private async void MateriasNavigationMethod()
        {
            await Nav.NavigateAsync(nameof(Views.MateriasPage));
        }

        private async void DocentesNavigationMethod()
        {
            await Nav.NavigateAsync(nameof(Views.DocentesPAGE));
        }
        #endregion
    }
}



