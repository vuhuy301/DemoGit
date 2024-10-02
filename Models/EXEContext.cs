using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BilliardShop.Models
{
    public partial class EXEContext : DbContext
    {
        public EXEContext()
        {
        }

        public EXEContext(DbContextOptions<EXEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImg> ProductImgs { get; set; } = null!;
        public virtual DbSet<ProductSize> ProductSizes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseSqlServer(conf.GetConnectionString("DbContext"));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.Bid);

                entity.ToTable("Banner");

                entity.Property(e => e.Bid).HasColumnName("bid");

                entity.Property(e => e.Blink).HasColumnName("blink");

                entity.Property(e => e.Burl).HasColumnName("burl");

                entity.Property(e => e.Des).HasColumnName("des");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.Blid);

                entity.ToTable("Blog");

                entity.Property(e => e.Blid).HasColumnName("blid");

                entity.Property(e => e.Blcontent).HasColumnName("blcontent");

                entity.Property(e => e.Bldtitle).HasColumnName("bldtitle");

                entity.Property(e => e.Blimage).HasColumnName("blimage");

                entity.Property(e => e.Createdate)
                    .HasColumnType("date")
                    .HasColumnName("createdate");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("Category");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(200)
                    .HasColumnName("cname");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Pmid).HasColumnName("pmid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Totalamount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("totalamount");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.Pm)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Pmid)
                    .HasConstraintName("FK_Orders_PaymentMethod");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Otid);

                entity.Property(e => e.Otid).HasColumnName("otid");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Pid)
                    .HasMaxLength(50)
                    .HasColumnName("pid");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Psid).HasColumnName("psid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Oid)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_OrderItems_Products");

                entity.HasOne(d => d.Ps)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Psid)
                    .HasConstraintName("FK_OrderItems_ProductSize");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.Pmid);

                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Pmid).HasColumnName("pmid");

                entity.Property(e => e.Pmdes).HasColumnName("pmdes");

                entity.Property(e => e.Pmname)
                    .HasMaxLength(50)
                    .HasColumnName("pmname");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid)
                    .HasMaxLength(50)
                    .HasColumnName("pid");

                entity.Property(e => e.Capitalprice)
                    .HasColumnType("money")
                    .HasColumnName("capitalprice");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Datecreate)
                    .HasColumnType("date")
                    .HasColumnName("datecreate");

                entity.Property(e => e.Pdes).HasColumnName("pdes");

                entity.Property(e => e.Pname)
                    .HasMaxLength(200)
                    .HasColumnName("pname");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Scid).HasColumnName("scid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Products_Category");

                entity.HasOne(d => d.Sc)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Scid)
                    .HasConstraintName("FK_Products_SubCategory");

				entity.Property(d => d.Sale) 
			    .HasColumnName("sale"); 
			});

            modelBuilder.Entity<ProductImg>(entity =>
            {
                entity.HasKey(e => e.Pimgid);

                entity.ToTable("ProductImg");

                entity.Property(e => e.Pimgid).HasColumnName("pimgid");

                entity.Property(e => e.Pid)
                    .HasMaxLength(50)
                    .HasColumnName("pid");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.ProductImgs)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_ProductImg_Products");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(e => e.Psid);

                entity.ToTable("ProductSize");

                entity.Property(e => e.Psid).HasColumnName("psid");

                entity.Property(e => e.Pid)
                    .HasMaxLength(50)
                    .HasColumnName("pid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_ProductSize_Products");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK_ProductSize_Size");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("Role");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Rname)
                    .HasMaxLength(50)
                    .HasColumnName("rname");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("Size");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.Property(e => e.Sname)
                    .HasMaxLength(50)
                    .HasColumnName("sname");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(e => e.Scid);

                entity.ToTable("SubCategory");

                entity.Property(e => e.Scid).HasColumnName("scid");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Scname)
                    .HasMaxLength(50)
                    .HasColumnName("scname");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_SubCategory_Category");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Uname)
                    .HasMaxLength(50)
                    .HasColumnName("uname");

                entity.Property(e => e.Upass)
                    .HasMaxLength(50)
                    .HasColumnName("upass");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
