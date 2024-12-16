

public class IEntity<T> where T : class
{
    public required T Id { get; set; }
    public long CreatedDate { get; set; }
    public long UpdatedDate { get; set; }
    public long? DeletedDate { get; set; }
}