using System.IO;

namespace YAML_schema_validator
{
    class ReadFiles
    {
        public readonly string jsonDom;
        public readonly string ymlDom;

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

            using(var reader = new StreamReader(jsonPath))
            {
                jsonDom = reader.ReadToEnd();
            }

            using(var reader = new StreamReader(ymlPath))
            {
                ymlDom = reader.ReadToEnd();
            }
        }
    }
}
