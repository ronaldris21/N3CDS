namespace MasterYUGIOHAppFinal.Patterns
{
    using Models;
    public class Singleton
    {
        private static Singleton _Instance;
        public static Singleton Instance
        {
            get => (_Instance == null) ? _Instance = new Singleton() : _Instance;
        }
        public AllCardsData AllData { get; set; }

    }
}
