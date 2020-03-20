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
        [Option('y', "yaml", Required = true, HelpText = "YAML file to validate")]
        public string yaml { get; set; }

        [Option('j', "json", HelpText = "JSON schema to compare")]
        public string json { get; set; }
    }
}
