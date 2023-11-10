using Element.GIS.Fx;
using System.Collections.Generic;
using System;

namespace Element.GIS.Plugin.DataConverter
{
    public class ToGeoJson : ToFile
    {
        protected override void FillHandles(Dictionary<string, Action<Options, IHostGrpc>> handles)
        {
            handles.Add(".shp", Shp2Geojson);
        }

        private void Shp2Geojson(Options options, IHostGrpc grpc)
        {
            var output = options.Output;
            if (string.IsNullOrEmpty(output))
            {
                output = $"{options.File}.geojson";
            }

            Tools.Shp2Geojson(options.File, output);
        }
    }
}