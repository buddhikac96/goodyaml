using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

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
            var yamlFile = new YamlFile(opts.yaml);
            var yamlstring = yamlFile.YamlDom;

            var jsonFile = new JsonSchemaFile(opts.json);
            var jsonString = jsonFile.JsonDom;

            //Console.WriteLine(yamlstring);
            //Console.WriteLine(jsonString);

            var jsonstringfromyaml = yamlFile.GetJsonFromYaml();
            Console.WriteLine(jsonstringfromyaml);
        }

        static void NotParsed(IEnumerable<Error> erros)
        {
            Console.WriteLine("Error occured when arg parsing");
        }
    }
}
