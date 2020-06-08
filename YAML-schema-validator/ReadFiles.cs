using System.IO;

namespace YAML_schema_validator
{
    class ReadFiles
    {
        public readonly TextReader JSON;
        public readonly TextReader YAML;

        public ReadFiles(string jsonPath, string ymlPath)
        {
            string jsonFile = Path.GetFileNameWithoutExtension(jsonPath);
            string ymlFile = Path.GetFileNameWithoutExtension(ymlPath);

            if (!File.Exists(jsonPath))
            {
                throw new FileNotFoundException("Cannot find " + jsonFile + ".json at the location " + Path.GetDirectoryName(jsonPath));
            }
            if (!File.Exists(ymlPath))
            {
                throw new FileNotFoundException("Cannot find " + ymlFile + ".yml at the location " + Path.GetDirectoryName(ymlPath));
            }

            JSON = new StreamReader(jsonPath);
            YAML = new StreamReader(ymlPath);
        }
    }
}
