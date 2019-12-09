using Prism.Commands;
using Prism.Mvvm;
using PrismSchoolWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSchoolRegister.ViewModels
{
    public class DocentesPAGEViewModel  : Prism.Mvvm.BindableBase
    {
        private Prism.Navigation.INavigationService Nav;
        public DocentesPAGEViewModel(Prism.Navigation.INavigationService nav)
        {
            Nav = nav;
        }


        
    }
}
