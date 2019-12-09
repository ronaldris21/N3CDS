namespace MasterYUGIOHAppFinal.Services
{

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    public static class JsonFilePath
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string JsonMain = Path.Combine(path, "YugiOhMaterCards.json");

        //Asegurate de hacer esto:
        //Build Action -> Embedded resource
        public static string Embeded_FileName = $"MasterYUGIOHAppFinal.EmbededSources.YUGIOHCardsData.json";
    }


    public class JsonLocalHandler
    {

        public void SaveData<T>(T Cartas, string Jsonpath)
        {
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(Cartas);

            using (var file = File.Open(Jsonpath, FileMode.Create, FileAccess.Write))

            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
                strm.Close();
            }
        }
        public async Task<T> ReadSavedData<T>(string Jsonpath)
        {
            using (var file = File.Open(Jsonpath, FileMode.Open, FileAccess.Read))

            using (var strm = new StreamReader(file))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await strm.ReadToEndAsync());
            }
        }

        public async Task<T> ReadFromJsonEmbededFile<T>(string JsonFileEmbeded)
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JsonLocalHandler)).Assembly;
                Stream stream = assembly.GetManifestResourceStream(JsonFileEmbeded);

                using (var reader = new System.IO.StreamReader(stream))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync());
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }

        public bool ExistsSavedJsonData(string JsonFilePath)
        {
            return File.Exists(JsonFilePath);
        }
    }
}