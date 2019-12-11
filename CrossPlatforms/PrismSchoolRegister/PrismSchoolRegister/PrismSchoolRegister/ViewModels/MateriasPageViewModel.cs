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
    public class MateriasPageViewModel : Prism.Mvvm.BindableBase
    {
        private JsonLocalHandler jsonHandler;
        private INavigationService Nav { get; set; }
        public MateriasPageViewModel(INavigationService nav)
        {
            IsNotBusy = true;
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
            IsBusy = true;
            AllMaterias.Add(MateriaNueva);
            MateriaNueva = new Materia();
            jsonHandler.SaveData<ObservableCollection<Materia>>(AllMaterias,jsonHandler.MateriasJson);
            IsBusy = false;
        }

        private  void RefreshMethod()
        {
            if(IsBusy)
            {
                return;
            }
            IsBusy = true;
            
            try
            {
                Task.Run(async () => AllMaterias = await jsonHandler.ReadSavedData<ObservableCollection<Materia>>(jsonHandler.MateriasJson)).Wait();
                if (AllMaterias == null)
                {
                    AllMaterias = new ObservableCollection<Materia>();
                }
                Task.Delay(100);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                AllMaterias = new ObservableCollection<Materia>();
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

        private string _carrera;
        public string Carrera
        {
            get { return _carrera; }
            set
            {
                SetProperty(ref _carrera, value);
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
