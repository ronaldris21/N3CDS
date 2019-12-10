namespace PrismSchoolWithLogin.Models
{
    public class Docente : Prism.Mvvm.BindableBase
    {
        private string _Nombre;
        private int _Edad;
        private string _Correo;


        public string Nombre
        {
            get => _Nombre;
            set => SetProperty(ref _Nombre, value);
        }
        public int Edad
        {
            get => _Edad;
            set => SetProperty(ref _Edad, value);
        }
        public string Correo
        {
            get => _Correo;
            set => SetProperty(ref _Correo, value);
        }

    }
}
