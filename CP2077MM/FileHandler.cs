using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CP2077MM
{
    class FileHandler
    {
        public FileHandler(string filePath)
        {
        }

        public static int updateJSON_FILE(string filePath, object json_data)
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            string output = JsonSerializer.Serialize(json_data, jsonOptions);

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(output);
            }

            return 0;
        }
    }
}
