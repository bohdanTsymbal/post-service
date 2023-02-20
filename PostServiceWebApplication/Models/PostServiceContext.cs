using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostServiceWebApplication.Models;

public partial class PostServiceContext : DbContext
{
    public PostServiceContext()
    {
    }

    public PostServiceContext(DbContextOptions<PostServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<Parcel> Parcels { get; set; }

    public virtual DbSet<ParcelHistory> ParcelHistories { get; set; }

    public virtual DbSet<ParcelType> ParcelTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-97Q88N1;Database=PostService; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.PhoneNumber);

            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PostOffices");

            entity.Property(e => e.Address).HasMaxLength(255);

            entity.HasOne(d => d.Type).WithMany(p => p.Locations)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_LocationTypes");
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Parcel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Parcel");

            entity.Property(e => e.ClientFromNumber).HasMaxLength(255);
            entity.Property(e => e.ClientToNumber).HasMaxLength(255);

            entity.HasOne(d => d.ClientFromNumberNavigation).WithMany(p => p.ParcelClientFromNumberNavigations)
                .HasForeignKey(d => d.ClientFromNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parcels_ClientsFrom");

            entity.HasOne(d => d.ClientToNumberNavigation).WithMany(p => p.ParcelClientToNumberNavigations)
                .HasForeignKey(d => d.ClientToNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parcels_ClientsTo");

            entity.HasOne(d => d.Type).WithMany(p => p.Parcels)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parcels_ParcelTypes");
        });

        modelBuilder.Entity<ParcelHistory>(entity =>
        {
            entity.ToTable("ParcelHistory");

            entity.Property(e => e.Datetime).HasColumnType("datetime");

            entity.HasOne(d => d.Location).WithMany(p => p.ParcelHistories)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParcelHistory_Locations");

            entity.HasOne(d => d.Parcel).WithMany(p => p.ParcelHistories)
                .HasForeignKey(d => d.ParcelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParcelHistory_Parcels");

            entity.HasOne(d => d.Status).WithMany(p => p.ParcelHistories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParcelHistory_Statuses");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
