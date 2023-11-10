using Element.GIS.Fx;
using System;

namespace Element.GIS.Plugin.DataConverter
{
    public class FormatConverterAttribute : Attribute
    {
        public FormatConverterAttribute(Type type)
        {
            ConverterType = type;
        }

        public Type ConverterType { get; private set; }

        public void Convert(Options option, IHostGrpc hostGrpc)
        {
            ToFile toFile = Activator.CreateInstance(ConverterType) as ToFile;
            if (toFile != null)
            {
                toFile.Convert(option, hostGrpc);
            }
        }
    }
}