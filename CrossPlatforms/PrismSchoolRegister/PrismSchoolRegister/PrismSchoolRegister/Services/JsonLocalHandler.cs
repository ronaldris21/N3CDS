

namespace PrismSchoolRegister.Services
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xamarin.Forms;


    public class JsonLocalHandler
    {
        public string EmbededDocentes = $"PrismSchoolRegister.EmbededSources.DocentesFile.json"; //only Works For Reading Data, not saving yet
        public string EmbededMaterias = $"PrismSchoolRegister.EmbededSources.MateriaFile.json";

        public string MateriasJson;
        public string DocentesJson;
        public JsonLocalHandler()
        {
            //Inicializar los nombres de los archivos!!!
            MateriasJson = "MateriasFile.json";
            DocentesJson = "DocentesFile.json";


            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Device.iOS == Device.RuntimePlatform)
            {
                folderpath = Path.Combine(folderpath, "..", "Library");
            }
            MateriasJson = Path.Combine(folderpath, MateriasJson);
            DocentesJson = Path.Combine(folderpath, DocentesJson);

        }
        public void SaveData<T>(T Cartas, string Jsonpath)
        {
            try
            {
                String result = Newtonsoft.Json.JsonConvert.SerializeObject(Cartas);

                using (var file = File.Open(Jsonpath, FileMode.Create, FileAccess.Write))

                using (var strm = new StreamWriter(file))
                {
                    strm.Write(result);
                    strm.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            
        }

        public async Task<T> ReadSavedData<T>(string Jsonpath)
        {
            try
            {
                using (var file = File.Open(Jsonpath, FileMode.Open, FileAccess.Read))

                using (var strm = new StreamReader(file))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await strm.ReadToEndAsync());
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return default(T);
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
