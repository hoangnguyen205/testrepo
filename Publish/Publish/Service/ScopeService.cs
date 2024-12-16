using System.Diagnostics;

namespace Publish.Service
{
    public class ScopeService( string? resourceId = null)
    {
        public string ResourceId { get; set; } = resourceId;
    }
}
