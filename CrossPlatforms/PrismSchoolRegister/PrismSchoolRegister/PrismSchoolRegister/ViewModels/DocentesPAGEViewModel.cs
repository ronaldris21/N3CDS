using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSchoolRegister.Services;
using PrismSchoolWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrismSchoolRegister.ViewModels
{
    public class DocentesPAGEViewModel  : Prism.Mvvm.BindableBase
    {
        private JsonLocalHandler jsonHandler;
        private INavigationService Nav { get; set; }
        public DocentesPAGEViewModel(Prism.Navigation.INavigationService nav)
        {
            Nav = nav;
            DocenteNueva = new Docente();
            jsonHandler = new JsonLocalHandler();
            AllDocentes = new ObservableCollection<Docente>();
            RefreshMethod();
        }

        #region Commands
        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand { get => _addCommand == null ? _addCommand = new DelegateCommand(AddMethod) : _addCommand; }



        private DelegateCommand _RefreshCommand;
        public DelegateCommand RefreshCommand { get => _RefreshCommand == null ? _RefreshCommand = new DelegateCommand(RefreshMethod) : _RefreshCommand; }



        #endregion

        #region METODOS
        private void AddMethod()
        {
            IsBusy = true;
            AllDocentes.Add(DocenteNueva);
            DocenteNueva = new Docente();
            jsonHandler.SaveData<ObservableCollection<Docente>>(AllDocentes, JsonFilePath.DocentesJson);
            IsBusy = false;
        }

        private void RefreshMethod()
        {
            IsBusy = true;
            try
            {
                Task.Run(async () => AllDocentes = await jsonHandler.ReadFromJsonEmbededFile<ObservableCollection<Docente>>(Services.JsonFilePath.DocentesJson)).Wait();
                if (AllDocentes==null)
                {
                    AllDocentes = new ObservableCollection<Docente>();
                }
                Task.Delay(100);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                AllDocentes = new ObservableCollection<Docente>();
            }

            IsBusy = false;
        }
        #endregion

        #region Propiedades

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

        public ObservableCollection<Docente> AllDocentes { get; set; }
        private Docente Docente;
        public Docente DocenteNueva
        {
            get { return Docente; }
            set { SetProperty(ref Docente, value); }
        }
        #endregion

    }
}
