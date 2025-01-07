using System;
using System.Collections.Generic;
using LoanCalculatorAPI.Data.Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace LoanCalculatorAPI.Data;

public partial class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<LoanAgeCalculation> LoanAgeCalculations { get; set; }

    public virtual DbSet<LoanPeriodExtraMonthInterest> LoanPeriodExtraMonthInterests { get; set; }

    public virtual DbSet<PrimeInterest> PrimeInterests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC0773E7B9D0");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        modelBuilder.Entity<LoanAgeCalculation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoanAgeC__3214EC07F8A710E4");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoanMaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoanMinAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.LoanPeriodExtraMonthInterest).WithMany(p => p.LoanAgeCalculations)
                .HasForeignKey(d => d.LoanPeriodExtraMonthInterestId)
                .HasConstraintName("FK__LoanAgeCa__LoanP__3F466844");
        });

        modelBuilder.Entity<LoanPeriodExtraMonthInterest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoanPeri__3214EC07E0C0A00B");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExtraMonthInterestRate).HasColumnType("decimal(5, 4)");
        });

        modelBuilder.Entity<PrimeInterest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrimeInt__3214EC07C5D0E477");

            entity.ToTable("PrimeInterest");

            entity.Property(e => e.EffectiveDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}