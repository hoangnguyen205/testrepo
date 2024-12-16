using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Publish.Model
{
    //public record Resource(string? name, string? path, string? username, string? resourceschema, string? resourcevalue,  int? type, int? status, string id, long? createddate, long? updateddate, long? deleteddate);

    public class Resource : IEntity<string>
    {
        [StringLength(512)]
        public required string Name { get; set; }

        [StringLength(Int32.MaxValue)]
        public required string Path { get; set; } 

        public required string Username { get; set; } 
        public string? ResourceSchema { get; set; }
        public string? ResourceValue { get; set; }
        public string? ResourceShare { get; set; }
        public long? ResourceShareTime { get; set; }

        public int Index { get; set; } = 0;

        public int Type { get; set; } 
        public int Status { get; set; } 
    }

    public record ResourceDto(List<Resource> created);

}
