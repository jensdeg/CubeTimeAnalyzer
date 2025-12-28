using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace CubeTimeAnalyzer.Api.Infrastructure;

public class CubeTimeAnalyzerContext(DbContextOptions<CubeTimeAnalyzerContext> options) : DbContext(options)
{
    public DbSet<Time> Times { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Time>(e =>
        {
            e.HasKey(t => t.TimeId);
            e.Property(t => t.CubeType)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<CubeType>(v));
            e.Property(t => t.Penalty)
                .HasConversion(
                    v => v.ToString(),
                    v => Enum.Parse<Penalty>(v));
        });

    }
}
