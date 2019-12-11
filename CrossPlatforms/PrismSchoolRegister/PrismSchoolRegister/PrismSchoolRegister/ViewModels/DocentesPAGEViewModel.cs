using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using PrismSchoolRegister.Services;
using PrismSchoolWithLogin.Models;

namespace PrismSchoolRegister.ViewModels
{
    public class DocentesPAGEViewModel  : Prism.Mvvm.BindableBase
    {
        private JsonLocalHandler jsonHandler;
        private INavigationService Nav { get; set; }
        public DocentesPAGEViewModel(Prism.Navigation.INavigationService nav)
        {
            IsNotBusy = true;
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
            jsonHandler.SaveData<ObservableCollection<Docente>>(AllDocentes, jsonHandler.DocentesJson);
            IsBusy = false;
        }

        private void RefreshMethod()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            try
            {
                Task.Run(async () => AllDocentes = await jsonHandler.ReadSavedData<ObservableCollection<Docente>>(jsonHandler.DocentesJson)).Wait();
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
