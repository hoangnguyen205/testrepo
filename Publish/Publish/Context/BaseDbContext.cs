using Microsoft.EntityFrameworkCore;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{
    public string Schema { get; set; } = string.Empty;
    public string Resource { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
}
