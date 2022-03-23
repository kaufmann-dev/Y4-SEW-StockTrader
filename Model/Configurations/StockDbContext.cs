using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class StockDbContext: DbContext
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Trader> Traders { get; set; }
    public DbSet<Trading> Tradings { get; set; }

    public StockDbContext(DbContextOptions<StockDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Stock>().HasIndex(n => n.Name).IsUnique();
        
        builder.Entity<Trading>().HasKey(m => new {
            m.TraderId,
            m.StockId,
            m.TradedAt
        });

        builder.Entity<Trading>().HasOne(m => m.Stock)
            .WithMany()
            .HasForeignKey(m => m.StockId);

        builder.Entity<Trading>().HasOne(m => m.Trader)
            .WithMany(m => m.Tradings)
            .HasForeignKey(m => m.TraderId);
    }
}
