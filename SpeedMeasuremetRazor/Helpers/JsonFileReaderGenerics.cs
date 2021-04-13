using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpeedMeasuremetRazor.Helpers
{
    public class JsonFileReaderGenerics<T>
    {
        public static T ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public async static Task<T> ReadJsonAsync(string filePath)
        {
            string jsonString = await File.ReadAllTextAsync(filePath);
            
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

    }
}
