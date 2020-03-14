using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace YAML_schema_validator
{
    public class YamlFile
    {
        private string YamlDom;

        private readonly string CurrentWorkingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private string YamlFilePath;

        private string YamlFileName;

        public string GetYamlFile(string yamlFileName)
        {
            if (yamlFileName.Contains(".yaml"))
            {
                yamlFileName = yamlFileName.Substring(0, yamlFileName.Length - 5);
                Console.WriteLine(yamlFileName);
            }

            if(!File.Exists(Path.Combine(CurrentWorkingDirectory, yamlFileName + ".yaml")))
            {
                throw new FileNotFoundException("Unable to locate " + yamlFileName + ".yaml in the current directory");
            }

            YamlFileName = yamlFileName + ".yaml";

            YamlFilePath = Path.Combine(CurrentWorkingDirectory, YamlFileName);

            using (var reader = new StreamReader(YamlFilePath))
            {
                YamlDom = reader.ReadToEnd();
            }

            return YamlDom;
        }
    }
}
