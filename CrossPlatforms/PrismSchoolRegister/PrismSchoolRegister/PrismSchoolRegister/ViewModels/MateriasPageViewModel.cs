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
    public class MateriasPageViewModel : Prism.Mvvm.BindableBase
    {
        private JsonLocalHandler jsonHandler;
        private INavigationService Nav { get; set; }
        public MateriasPageViewModel(INavigationService nav)
        {
            Nav = nav;
            MateriaNueva = new Materia();
            jsonHandler = new JsonLocalHandler();
            AllMaterias = new ObservableCollection<Materia>();
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
            AllMaterias.Add(MateriaNueva);
            MateriaNueva = new Materia();
            jsonHandler.SaveData<ObservableCollection<Materia>>(AllMaterias,JsonFilePath.MateriasJson);
        }

        private  void RefreshMethod()
        {
            IsBusy = true;
            if (!jsonHandler.ExistsSavedJsonData(Services.JsonFilePath.MateriasJson))
            {
                AllMaterias = new ObservableCollection<Materia>();
            }
            else
            {
                try
                {
                    Task.Run(async () => AllMaterias = await jsonHandler.ReadSavedData<ObservableCollection<Materia>>(Services.JsonFilePath.MateriasJson)).Wait();
                    Task.Delay(100);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                    AllMaterias = new ObservableCollection<Materia>();
                }
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
        public ObservableCollection<Materia> AllMaterias { get; set; }
        private Materia materia;
        public Materia MateriaNueva
        {
            get { return materia; }
            set { SetProperty(ref materia, value); }
        }
        #endregion

    }
}
