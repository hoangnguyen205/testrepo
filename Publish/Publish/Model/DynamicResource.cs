
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Publish.Model
{
    public class DynamicResource : IEntity<string>
    {
        public string? Geom { get; set; }
        public string Data { get; set; }
        public string ResourceId { get; set; }
    }

    public record DynamicResourceDto( List<DynamicResource> created);
}
