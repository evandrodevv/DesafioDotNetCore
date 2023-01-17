using Microsoft.EntityFrameworkCore;
using APIKhipo.ViewModels;

namespace APIKhipo.Models;

public class KHIDBContext : DbContext
{
    public KHIDBContext()
    {
    }

    public KHIDBContext(DbContextOptions<KHIDBContext> options)
        : base(options)
    {
    }

    public DbSet<Products> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.createdAt)
                    .HasColumnName("CREATEDAT")
                    .HasColumnType("datetime")                    
                    .IsRequired();

                entity.Property(e => e.name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.price)
                    .HasColumnName("PRICE")
                    .IsRequired();

                entity.Property(e => e.brand)
                    .HasColumnName("BRAND")
                    .HasMaxLength(255)
                    .IsUnicode(false);                    

                entity.Property(e => e.updatedAt)
                    .HasColumnName("UPDATEDAT")
                    .HasColumnType("datetime")                    
                    .IsRequired();

                entity.Property(e => e.id).HasColumnName("ID");
                                              
            });            
        }
}