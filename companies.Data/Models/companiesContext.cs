using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace companies.Data.Models
{
    public partial class companiesContext : DbContext
    {
        public companiesContext()
        {
        }

        public companiesContext(DbContextOptions<companiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Positionemployee> Positionemployees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Companyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_companyid_fkey");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Positionname)
                    .HasMaxLength(50)
                    .HasColumnName("positionname");
            });

            modelBuilder.Entity<Positionemployee>(entity =>
            {
                entity.ToTable("positionemployee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Positionid).HasColumnName("positionid");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Positionemployees)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("positionemployee_employeeid_fkey");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Positionemployees)
                    .HasForeignKey(d => d.Positionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("positionemployee_positionid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
