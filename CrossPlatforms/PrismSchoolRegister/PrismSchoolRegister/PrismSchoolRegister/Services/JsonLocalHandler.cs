

namespace PrismSchoolRegister.Services
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    public static class JsonFilePath
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string MateriasJson = Path.Combine(path, "MateriasJson.json");
        public static string DocentesJson = Path.Combine(path, "DocentesJson.json");

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


        public bool ExistsSavedJsonData(string JsonFilePath)
        {
            return File.Exists(JsonFilePath);
        }
    }
}
