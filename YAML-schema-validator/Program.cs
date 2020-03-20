using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace YAML_schema_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Parsed)
                .WithNotParsed(NotParsed);
        }

        static void Parsed(Options opts)
        {
            try
            {
                //Generating Json Schema from C# class
                JSchema schema = new JSchemaGenerator().Generate(typeof(JsonSchemaType));

                //Read json from file
                //String jsonString = new JsonSchemaFile(opts.json).JsonDom;

                //Generating Json schema from json
                //JsonSchema schema = JsonSchema.Parse(jsonString);

                //Get Json String from YAML file
                var jsonstringfromyaml = new YamlFile(opts.yaml).GetJsonFromYaml();

                //Parsing json string from yaml into JObject
                JObject student = JObject.Parse(jsonstringfromyaml);

                //validate JObject with schema
                bool valid = student.IsValid(schema);

                Console.WriteLine(valid);
            }
            catch
            {
                Console.WriteLine("Error occured during validating");
            }
            
        }

        static void NotParsed(IEnumerable<Error> erros)
        {
            Console.WriteLine("Error occured during arg parsing");
        }
    }
}
