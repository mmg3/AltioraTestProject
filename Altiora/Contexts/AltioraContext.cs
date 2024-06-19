using Altiora.Models;
using Microsoft.EntityFrameworkCore;

namespace Altiora.Contexts;

public partial class AltioraContext : DbContext
{
    public AltioraContext()
    {
    }

    public AltioraContext(DbContextOptions<AltioraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Id);
            entity.Property(e => e.Code);
            entity.Property(e => e.Name);
            entity.Property(e => e.UnitPrice);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id);
            entity.Property(e => e.Email);
            entity.Property(e => e.FirstName);
            entity.Property(e => e.Identification)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.LastName);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id);
            entity.Property(e => e.ClientId);
            entity.Property(e => e.Code);

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id);
            entity.Property(e => e.ArticleId);
            entity.Property(e => e.OrderId);
            entity.Property(e => e.Quantity);
            entity.Property(e => e.UnitPrice);

            entity.HasOne(d => d.Article).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
