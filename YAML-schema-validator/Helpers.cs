using System.IO;
using YamlDotNet.Serialization;

namespace YAML_schema_validator
{
    public class Helper
    {
        public static string ConvertYamlToJson(TextReader yml)
        {
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(yml);

            var serializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            var json = serializer.Serialize(yamlObject);

            return json;
        }
    }
}
