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

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Cartproduct> Cartproducts { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderproduct> Orderproducts { get; set; }
        public virtual DbSet<RecFormat> RecFormats { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdCust).HasColumnName("idCust");

                entity.HasOne(d => d.IdCustNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.IdCust)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__idCust__32024716");
            });

            modelBuilder.Entity<Cartproduct>(entity =>
            {
                entity.ToTable("cartproducts");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdCart).HasColumnName("idCart");

                entity.Property(e => e.IdProd).HasColumnName("idProd");

                entity.Property(e => e.ProductQuant).HasColumnName("productQuant");

                entity.HasOne(d => d.IdCartNavigation)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.IdCart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cartprodu__idCar__35D2D7FA");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.IdProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cartprodu__idPro__34DEB3C1");
            });

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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("eMail");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fName");

                entity.Property(e => e.LName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lName");

                entity.Property(e => e.Zip).HasColumnName("zip");
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
                    .HasName("PK__inventor__3C3EB36A67A0DF14");

                entity.ToTable("inventory");

                entity.Property(e => e.IdInv)
                    .ValueGeneratedNever()
                    .HasColumnName("idInv");

                entity.Property(e => e.IdLoc).HasColumnName("idLoc");

                entity.Property(e => e.IdRec).HasColumnName("idRec");

                entity.HasOne(d => d.IdLocNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IdLoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__idLoc__2F25DA6B");

                entity.HasOne(d => d.IdRecNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IdRec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__idRec__2E31B632");
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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdCart).HasColumnName("idCart");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.ODate)
                    .HasColumnType("date")
                    .HasColumnName("o_date");

                entity.HasOne(d => d.IdCartNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__idCart__39A368DE");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__location__38AF44A5");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.ToTable("orderproducts");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Idorder).HasColumnName("idorder");

                entity.Property(e => e.Idproducts).HasColumnName("idproducts");

                entity.Property(e => e.Productnumb).HasColumnName("productnumb");

                entity.HasOne(d => d.IdorderNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.Idorder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderprod__idord__3D73F9C2");

                entity.HasOne(d => d.IdproductsNavigation)
                    .WithMany(p => p.Orderproducts)
                    .HasForeignKey(d => d.Idproducts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orderprod__idpro__3C7FD589");
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
                    .HasConstraintName("FK__records__conditi__2690946A");

                entity.HasOne(d => d.GenreNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Genre)
                    .HasConstraintName("FK__records__genre__259C7031");

                entity.HasOne(d => d.RecFormatNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.RecFormat)
                    .HasConstraintName("FK__records__recForm__2784B8A3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
