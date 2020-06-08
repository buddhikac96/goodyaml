using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace YAML_schema_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run(args);
            }
            catch(InvalidDataException)
            {
                Console.WriteLine("Invalid file paths");
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Run(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Parsed)
                .WithNotParsed(NotParsed);
        }

        static void Parsed(Options opts)
        {
            var readFiles = new ReadFiles(opts.json, opts.yml);
            var isValid = Validator.YamlValidateJson(readFiles.YAML, readFiles.JSON);

            if (isValid)
            {
                Console.WriteLine("Valid Yaml");
            }
            else
            {
                Console.WriteLine("Invalid Yaml");
            }

        }

        static void NotParsed(IEnumerable<Error> erros)
        {
            Console.WriteLine("Error occured during arg parsing");
        }
    }
}
