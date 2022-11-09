using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.NZWalks.Infrastructure.Entities;

public partial class NzwalksDbContext : DbContext
{
    public NzwalksDbContext()
    {
    }

    public NzwalksDbContext(DbContextOptions<NzwalksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Walk> Walks { get; set; }

    public virtual DbSet<WalkDifficulty> WalkDifficulties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=.;Database=NZWalksDb;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Walk>(entity =>
        {
            entity.HasIndex(e => e.RegionId, "IX_Walks_RegionId");

            entity.HasIndex(e => e.WalkDifficultyId, "IX_Walks_WalkDifficultyId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Region).WithMany(p => p.Walks).HasForeignKey(d => d.RegionId);

            entity.HasOne(d => d.WalkDifficulty).WithMany(p => p.Walks).HasForeignKey(d => d.WalkDifficultyId);
        });

        modelBuilder.Entity<WalkDifficulty>(entity =>
        {
            entity.ToTable("WalkDifficulty");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
