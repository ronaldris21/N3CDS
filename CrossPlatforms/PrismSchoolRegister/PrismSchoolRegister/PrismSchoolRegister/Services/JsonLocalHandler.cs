

namespace PrismSchoolRegister.Services
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    public static class JsonFilePath
    {

        //Asegurate de hacer esto:
        //Build Action -> Embedded resource
        public static string MateriasJson = $"PrismSchoolRegister.EmbededSources.MateriaFile.json";
        public static string DocentesJson = $"PrismSchoolRegister.EmbededSources.DocentesFile.json";

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
