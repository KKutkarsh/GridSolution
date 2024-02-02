using Newtonsoft.Json;
using System.Reflection;

namespace GridFunction.UnitTests.Utils
{
    public static class SerializationUtils
    {
        public static string GetFilePath(string fileName)
        {
            string initPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Factory", "JsonFiles");
            return Path.Combine(initPath, fileName);
        }

        public static T DeserializeFile<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(GetFilePath(fileName)));
        }
    }
}
