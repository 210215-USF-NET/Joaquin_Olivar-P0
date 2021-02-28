using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GRDL.Entities
{
    public partial class GRdatabaseContext : DbContext
    {
        public GRdatabaseContext()
        {
        }

        public GRdatabaseContext(DbContextOptions<GRdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<RecFormat> RecFormats { get; set; }
        public virtual DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("condition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConditionName)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("conditionName")
                    .HasDefaultValueSql("('New')");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("genreName")
                    .HasDefaultValueSql("('Rap')");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.IdInv)
                    .HasName("PK__inventor__3C3EB36ADC9CDDAB");

                entity.ToTable("inventories");

                entity.Property(e => e.IdInv)
                    .ValueGeneratedNever()
                    .HasColumnName("idInv");

                entity.Property(e => e.IdLoc).HasColumnName("idLoc");

                entity.Property(e => e.IdRec).HasColumnName("idRec");

                entity.HasOne(d => d.IdLocNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IdLoc)
                    .HasConstraintName("FK__inventori__idLoc__25FB978D");

                entity.HasOne(d => d.IdRecNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IdRec)
                    .HasConstraintName("FK__inventori__idRec__25077354");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("locName");
            });

            modelBuilder.Entity<RecFormat>(entity =>
            {
                entity.ToTable("recFormat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("formName")
                    .HasDefaultValueSql("('Vinyl')");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("records");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("artistName");

                entity.Property(e => e.Condition).HasColumnName("condition");

                entity.Property(e => e.Genre).HasColumnName("genre");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RecFormat).HasColumnName("recFormat");

                entity.Property(e => e.RecordName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("recordName");

                entity.HasOne(d => d.ConditionNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Condition)
                    .HasConstraintName("FK__records__conditi__1F4E99FE");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Genre)
                    .HasConstraintName("FK__records__genre__1E5A75C5");

                entity.HasOne(d => d.RecFormatNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.RecFormat)
                    .HasConstraintName("FK__records__recForm__2042BE37");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
