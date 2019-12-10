namespace PrismSchoolWithLogin.Models
{
    public class Materia : Prism.Mvvm.BindableBase
    {
        private string _materianame;
        private string _carrera;
        private int _cum;

        public string MateriaName
        {
            get => _materianame;
            set => SetProperty(ref _materianame, value);
        }
        public string Carrera
        {
            get => _carrera;
            set => SetProperty(ref _carrera, value);
        }
        public int CantCum
        {
            get => _cum;
            set => SetProperty(ref _cum, value);
        }
    }
}
