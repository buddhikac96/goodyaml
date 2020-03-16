using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using YamlDotNet.Serialization;
using Newtonsoft.Json;

namespace YAML_schema_validator
{
    public class YamlFile
    {
        public string YamlDom { get; private set; }

        private readonly string CurrentWorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public YamlFile(string yamlFileName)
        {
            if (yamlFileName.Contains(".yaml"))
            {
                yamlFileName = yamlFileName.Substring(0, yamlFileName.Length - 5);
                Console.WriteLine(yamlFileName);
            }

            if (!File.Exists(Path.Combine(CurrentWorkingDirectory, yamlFileName + ".yaml")))
            {
                throw new FileNotFoundException("Unable to locate " + yamlFileName + ".yaml in the current directory");
            }

            var YamlFileName = yamlFileName + ".yaml";

            var YamlFilePath = Path.Combine(CurrentWorkingDirectory, YamlFileName);

            using (var reader = new StreamReader(YamlFilePath))
            {
                YamlDom = reader.ReadToEnd();
            }
        }

        public string GetJsonFromYaml()
        {
            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(new StringReader(YamlDom));

            string jsonString = JsonConvert.SerializeObject(yamlObject);
            return jsonString;
        }
    }
}
