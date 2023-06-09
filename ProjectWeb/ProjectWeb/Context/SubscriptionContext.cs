using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;

namespace ProjectWeb.Context;

public partial class SubscriptionContext : DbContext
{
    public SubscriptionContext()
    {
    }

    public SubscriptionContext(DbContextOptions<SubscriptionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ProductService> ProductServices { get; set; }

    public virtual DbSet<SubscriptionTier> SubscriptionTiers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE488EDF6D0FD");

            entity.ToTable("Admin");

            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__ProductS__C51BB00AD3848CFE");

            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubscriptionTier>(entity =>
        {
            entity.HasKey(e => e.SubscriptionTierId).HasName("PK__Subscrip__565AAF057BD9C830");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TierName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Service).WithMany(p => p.SubscriptionTiers)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Subscript__Servi__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C9A54C6B9");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__UserSubs__9A2B249D0F61CC7A");

            entity.Property(e => e.SubscriptionDate).HasColumnType("date");
            entity.Property(e => e.SubscriptionDateEndDate).HasColumnType("date");

            entity.HasOne(d => d.SubscriptionTier).WithMany(p => p.UserSubscriptions)
                .HasForeignKey(d => d.SubscriptionTierId)
                .HasConstraintName("FK__UserSubsc__Subsc__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserSubsc__UserI__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
