using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAML_schema_validator
{
    public class Options
    {
        [Option('y', "yml", Required = true, HelpText = "YML file to validate")]
        public string yml { get; set; }

        [Option('j', "json", HelpText = "JSON schema to compare")]
        public string json { get; set; }
    }
}
