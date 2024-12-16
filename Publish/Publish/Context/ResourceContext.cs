using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;
using Publish.Model;
using System.Reflection.Emit;

public class ResourceContext : BaseDbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<DynamicResource> DynamicResources { get; set; }

    public ResourceContext(DbContextOptions<ResourceContext> options)
        : base(options)
    {
    }

    // Optionally, override OnModelCreating for custom configurations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Resource>().ToTable("Resource");

        if (!string.IsNullOrEmpty(Resource))
        {
            modelBuilder.Entity<DynamicResource>().ToTable(Resource);
            //modelBuilder.Entity<DynamicResource>(entity =>
            //{
            //    entity.ToTable(Resource);
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.CreatedDate);
            //    entity.Property(e => e.UpdatedDate);
            //    entity.Property(e => e.DeletedDate);
            //    entity.Property(e => e.Data).HasColumnType("json"); ;
            //    entity.Property(e => e.Geom).HasColumnType("geometry");
            //});
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableServiceProviderCaching(false);
        optionsBuilder.ReplaceService<IModelCacheKeyFactory, EntityModelCacheKey>();
    }

    public void ReSetModel()
    {
        ModelBuilder model = new ModelBuilder();
        OnModelCreating(model);
    }

}

