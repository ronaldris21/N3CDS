using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PrismSchoolWithLogin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
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
