using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;

namespace YAML_schema_validator
{
    public class Validator
    {
        public static bool YamlValidateJson(TextReader yaml, TextReader jsonSchema)
        {
            var jsonObjectString = Helper.ConvertYamlToJson(yaml);
            var jsonSchemaString = jsonSchema.ReadToEnd();

            JsonSchema schema = JsonSchema.Parse(jsonSchemaString);
            JObject jsonObject = JObject.Parse(jsonObjectString);

            bool valid = jsonObject.IsValid(schema);

            return valid;
        }
    }
}
