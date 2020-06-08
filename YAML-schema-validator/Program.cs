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
                Console.Error.WriteLine("Invalid file paths");
            }catch(Exception)
            {
                Console.Error.WriteLine("Something is wrong");
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
            try
            {

                var readFiles = new ReadFiles(opts.json, opts.yml);

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
