namespace Element.GIS.Plugin.DataConverter
{
    public enum ConvertFormat
    {
        None = 0,
        [FormatConverter(typeof(ToShp))]
        shp = 1,
        [FormatConverter(typeof(ToGeoJson))]
        geojson = 2,
    }
}