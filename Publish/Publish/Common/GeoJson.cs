
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using Publish.Model;


public class GeoJson
{
    public Features[]? Features { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class Features
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Type { get; set; } = string.Empty;
    public dynamic Geometry { get; set; }
    public Dictionary<string, string>? Properties { get; set; }
}

