namespace PrismSchoolWithLogin.Models
{
    public class Docente
    {
        public int idDocente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }

        public override int GetHashCode()
        {
            return idDocente;
        }
    }
}
