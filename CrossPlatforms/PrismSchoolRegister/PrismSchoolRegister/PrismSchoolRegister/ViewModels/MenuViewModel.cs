

namespace PrismSchoolRegister.ViewModels
{
    using Prism.Commands;
    using Prism.Navigation;
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        #region Commands
        public DelegateCommand DocentesCommand { get => new DelegateCommand(() => DocentesNavigationMethod(null)); }

        private void DocentesNavigationMethod(object obj)
        {

        }
        #endregion
    }
}



