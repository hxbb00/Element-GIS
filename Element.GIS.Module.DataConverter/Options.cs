using CommandLine;

namespace Element.GIS.Plugin.DataConverter
{
    public class Options
    {
        [Option('f', "format", Required = true, HelpText = "输出格式。")]
        public ConvertFormat Format { get; set; }

        [Option('i', "input", Required = true, HelpText = "源文件。")]
        public string File { get; set; }

        [Option('o', "output", Required = false, HelpText = "输出文件。")]
        public string Output { get; set; }
    }
}