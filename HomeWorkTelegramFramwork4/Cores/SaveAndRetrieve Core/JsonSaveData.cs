using System;
using System.IO;
using System.Web.Script.Serialization;


namespace SaveAndRetrieve
{
    /// <summary>
    /// ذخیره و یا بازیابی اطلاعات با استفاده از تکنولوژی جیسون
    /// </summary>
    public class JsonSaveData
    {
        static JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public static void SaveData(object value,string path)
        {
            Console.WriteLine("asdads");
            var s = Serializer.Serialize(value);
            File.WriteAllText(path, s);
        }
        public static void AppendData(object value, string path)
        {
            File.AppendAllText(path, Serializer.Serialize(value));
        }
        public static T LoadData<T>(string path)
        {
            try
            {
                if (File.Exists(path))
                    return Serializer.Deserialize<T>(File.ReadAllText(path));
                else
                    throw new Exception("File not found.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}

