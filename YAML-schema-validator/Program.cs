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
            Console.WriteLine(opts.yaml);
            Console.WriteLine(opts.json);
        }

        static void NotParsed(IEnumerable<Error> erros)
        {
            Console.WriteLine("Error occured when arg parsing");
        }
    }
}
