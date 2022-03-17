using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace back_end.Models
{
    public partial class TECH_TEST_G_HURTADOContext : DbContext
    {
        public TECH_TEST_G_HURTADOContext()
        {
        }

        public TECH_TEST_G_HURTADOContext(DbContextOptions<TECH_TEST_G_HURTADOContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Functionary> Functionaries { get; set; } = null!;
        public virtual DbSet<Rank> Ranks { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             optionsBuilder.UseSqlServer("Data Source=localhost; initial catalog=TECH_TEST_G_HURTADO; persist security info=True; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Functionary>(entity =>
            {
                entity.HasKey(e => e.FunctionaryGpn);

                entity.ToTable("Functionary");

                entity.Property(e => e.FunctionaryGpn)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTIONARY_GPN");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.FunctionaryActive)
                    .HasColumnName("FUNCTIONARY_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FunctionaryEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTIONARY_EMAIL");

                entity.Property(e => e.FunctionaryLngName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTIONARY_LNG_NAME");

                entity.Property(e => e.FunctionaryRankCd).HasColumnName("FUNCTIONARY_RANK_CD");

                entity.Property(e => e.FunctionaryShtName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("FUNCTIONARY_SHT_NAME");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Functionaries)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Functionary_User");

                entity.HasOne(d => d.FunctionaryRankCdNavigation)
                    .WithMany(p => p.Functionaries)
                    .HasForeignKey(d => d.FunctionaryRankCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Functionary_Rank");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(e => e.RankCd)
                    .HasName("PK_RANK");

                entity.ToTable("Rank");

                entity.Property(e => e.RankCd).HasColumnName("RANK_CD");

                entity.Property(e => e.RankActive).HasColumnName("RANK_ACTIVE");

                entity.Property(e => e.RankDscr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RANK_DSCR");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleActive).HasColumnName("ROLE_ACTIVE");

                entity.Property(e => e.RoleDscr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_DSCR");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("User");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.UserActive).HasColumnName("USER_ACTIVE");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("USER_EMAIL");

                entity.Property(e => e.UserPass).HasColumnName("USER_PASS");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
