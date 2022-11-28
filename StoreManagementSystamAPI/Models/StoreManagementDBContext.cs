using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class StoreManagementDBContext : DbContext
    {
        public StoreManagementDBContext()
        {
        }

        public StoreManagementDBContext(DbContextOptions<StoreManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAdmin> TAdmins { get; set; }
        public virtual DbSet<TCustomer> TCustomers { get; set; }
        public virtual DbSet<TMenu> TMenus { get; set; }
        public virtual DbSet<TPaymentMood> TPaymentMoods { get; set; }
        public virtual DbSet<TProduct> TProducts { get; set; }
        public virtual DbSet<TProductCategory> TProductCategories { get; set; }
        public virtual DbSet<TPurchase> TPurchases { get; set; }
        public virtual DbSet<TRolesMenu> TRolesMenus { get; set; }
        public virtual DbSet<TSale> TSales { get; set; }
        public virtual DbSet<TShelf> TShelves { get; set; }
        public virtual DbSet<TStore> TStores { get; set; }
        public virtual DbSet<TSupplier> TSuppliers { get; set; }
        public virtual DbSet<TUserRole> TUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-4P7AU8H\\SQLEXPRESS01;Database=StoreManagementDB;Trusted_Connection=True;User ID=Jait;Password=jaiT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TAdmin>(entity =>
            {
                entity.ToTable("T_Admin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TAdmins)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Admin_UserRole");
            });

            modelBuilder.Entity<TCustomer>(entity =>
            {
                entity.ToTable("T_Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMenu>(entity =>
            {
                entity.ToTable("T_Menu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Menu_Menu");
            });

            modelBuilder.Entity<TPaymentMood>(entity =>
            {
                entity.ToTable("T_PaymentMood");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMood)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.ToTable("T_Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfId).HasColumnName("ShelfID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.TProducts)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK_T_Product_T_ProductCategory");

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.TProducts)
                    .HasForeignKey(d => d.ShelfId)
                    .HasConstraintName("FK_T_Product_T_Shelf");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TProducts)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_T_Product_T_Supplier");
            });

            modelBuilder.Entity<TProductCategory>(entity =>
            {
                entity.ToTable("T_ProductCategory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCategoryDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TPurchase>(entity =>
            {
                entity.ToTable("T_Purchase");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMoodId).HasColumnName("PaymentMoodID");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.PaymentMood)
                    .WithMany(p => p.TPurchases)
                    .HasForeignKey(d => d.PaymentMoodId)
                    .HasConstraintName("FK_T_Purchase_T_PaymentMood");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.TPurchases)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK_T_Purchase_T_ProductCategory");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TPurchases)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_T_Purchase_T_Product");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TPurchases)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_T_Purchase_T_Supplier");
            });

            modelBuilder.Entity<TRolesMenu>(entity =>
            {
                entity.ToTable("T_RolesMenu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.TRolesMenus)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_RolesMenu_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TRolesMenus)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolesMenu_UserRole");
            });

            modelBuilder.Entity<TSale>(entity =>
            {
                entity.ToTable("T_Sales");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMoodId).HasColumnName("PaymentMoodID");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TSales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_T_Sales_T_Customer");

                entity.HasOne(d => d.PaymentMood)
                    .WithMany(p => p.TSales)
                    .HasForeignKey(d => d.PaymentMoodId)
                    .HasConstraintName("FK_T_Sales_T_PaymentMood");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.TSales)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK_T_Sales_T_ProductCategory");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TSales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_T_Sales_T_Product");
            });

            modelBuilder.Entity<TShelf>(entity =>
            {
                entity.ToTable("T_Shelf");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.ShelfDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TStore>(entity =>
            {
                entity.ToTable("T_Store");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TSupplier>(entity =>
            {
                entity.ToTable("T_Supplier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUserRole>(entity =>
            {
                entity.ToTable("T_UserRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
