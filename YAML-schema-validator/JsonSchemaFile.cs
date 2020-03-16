using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YAML_schema_validator
{
    public class JsonSchemaFile
    {
        public string JsonDom { get; private set; }

        private readonly string CurrentWorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public JsonSchemaFile(string jsonSchemaFileName)
        {
            if (jsonSchemaFileName.Contains(".json"))
            {
                jsonSchemaFileName = jsonSchemaFileName.Substring(0, jsonSchemaFileName.Length - 5);
                Console.WriteLine(jsonSchemaFileName);
            }

            if (!File.Exists(Path.Combine(CurrentWorkingDirectory, jsonSchemaFileName + ".json")))
            {
                throw new FileNotFoundException("Unable to locate " + jsonSchemaFileName + ".json in the current directory");
            }

            var JsonSchemaFileName = jsonSchemaFileName + ".json";

            var JsonSchemaFilePath = Path.Combine(CurrentWorkingDirectory, JsonSchemaFileName);

            using (var reader = new StreamReader(JsonSchemaFilePath))
            {
                JsonDom = reader.ReadToEnd();
            }
        }
    }
}
