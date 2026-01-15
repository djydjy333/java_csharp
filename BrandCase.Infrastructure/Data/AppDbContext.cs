using BrandCase.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrandCase.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("tb_brand");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandName).HasColumnName("brand_name");
            entity.Property(e => e.CompanyName).HasColumnName("company_name");
            entity.Property(e => e.Ordered).HasColumnName("ordered");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Status).HasColumnName("status");
        });
    }
}
