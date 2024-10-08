﻿// <auto-generated />
using System;
using BilliardShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BilliardShop.Migrations
{
    [DbContext(typeof(EXEContext))]
    [Migration("20240827040804_MigrationName")]
    partial class MigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BilliardShop.Models.Banner", b =>
                {
                    b.Property<int>("Bid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bid"), 1L, 1);

                    b.Property<string>("Blink")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("blink");

                    b.Property<string>("Burl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("burl");

                    b.Property<string>("Des")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("des");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Bid");

                    b.ToTable("Banner", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.Blog", b =>
                {
                    b.Property<int>("Blid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("blid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Blid"), 1L, 1);

                    b.Property<string>("Blcontent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("blcontent");

                    b.Property<string>("Bldtitle")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("bldtitle");

                    b.Property<string>("Blimage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("blimage");

                    b.Property<DateTime?>("Createdate")
                        .HasColumnType("date")
                        .HasColumnName("createdate");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Blid");

                    b.ToTable("Blog", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.Category", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"), 1L, 1);

                    b.Property<string>("Cname")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("cname");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Cid");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.Order", b =>
                {
                    b.Property<int>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("oid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Oid"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("notes");

                    b.Property<DateTime?>("Orderdate")
                        .HasColumnType("date")
                        .HasColumnName("orderdate");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone");

                    b.Property<int?>("Pmid")
                        .HasColumnType("int")
                        .HasColumnName("pmid");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<decimal?>("Totalamount")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("totalamount");

                    b.Property<int?>("Uid")
                        .HasColumnType("int")
                        .HasColumnName("uid");

                    b.HasKey("Oid");

                    b.HasIndex("Pmid");

                    b.HasIndex("Uid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BilliardShop.Models.OrderItem", b =>
                {
                    b.Property<int>("Otid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("otid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Otid"), 1L, 1);

                    b.Property<int?>("Oid")
                        .HasColumnType("int")
                        .HasColumnName("oid");

                    b.Property<string>("Pid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pid");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<int?>("Psid")
                        .HasColumnType("int")
                        .HasColumnName("psid");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Otid");

                    b.HasIndex("Oid");

                    b.HasIndex("Pid");

                    b.HasIndex("Psid");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BilliardShop.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Pmid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pmid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pmid"), 1L, 1);

                    b.Property<string>("Pmdes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pmdes");

                    b.Property<string>("Pmname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pmname");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Pmid");

                    b.ToTable("PaymentMethod", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.Product", b =>
                {
                    b.Property<string>("Pid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pid");

                    b.Property<decimal?>("Capitalprice")
                        .HasColumnType("money")
                        .HasColumnName("capitalprice");

                    b.Property<int?>("Cid")
                        .HasColumnType("int")
                        .HasColumnName("cid");

                    b.Property<DateTime?>("Datecreate")
                        .HasColumnType("date")
                        .HasColumnName("datecreate");

                    b.Property<string>("Pdes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pdes");

                    b.Property<string>("Pname")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("pname");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<int?>("Scid")
                        .HasColumnType("int")
                        .HasColumnName("scid");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Pid");

                    b.HasIndex("Cid");

                    b.HasIndex("Scid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BilliardShop.Models.ProductImg", b =>
                {
                    b.Property<int>("Pimgid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("pimgid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pimgid"), 1L, 1);

                    b.Property<string>("Pid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pid");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url");

                    b.HasKey("Pimgid");

                    b.HasIndex("Pid");

                    b.ToTable("ProductImg", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.ProductSize", b =>
                {
                    b.Property<int>("Psid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("psid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Psid"), 1L, 1);

                    b.Property<string>("Pid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pid");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int?>("Sid")
                        .HasColumnType("int")
                        .HasColumnName("sid");

                    b.HasKey("Psid");

                    b.HasIndex("Pid");

                    b.HasIndex("Sid");

                    b.ToTable("ProductSize", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.Role", b =>
                {
                    b.Property<int>("Rid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rid"), 1L, 1);

                    b.Property<string>("Rname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("rname");

                    b.HasKey("Rid");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.Size", b =>
                {
                    b.Property<int>("Sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sid"), 1L, 1);

                    b.Property<string>("Sname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sname");

                    b.HasKey("Sid");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.SubCategory", b =>
                {
                    b.Property<int>("Scid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("scid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Scid"), 1L, 1);

                    b.Property<int?>("Cid")
                        .HasColumnType("int")
                        .HasColumnName("cid");

                    b.Property<string>("Scname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("scname");

                    b.HasKey("Scid");

                    b.HasIndex("Cid");

                    b.ToTable("SubCategory", (string)null);
                });

            modelBuilder.Entity("BilliardShop.Models.User", b =>
                {
                    b.Property<int>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("uid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Uid"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone");

                    b.Property<int?>("Rid")
                        .HasColumnType("int")
                        .HasColumnName("rid");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("Uname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("uname");

                    b.Property<string>("Upass")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("upass");

                    b.HasKey("Uid");

                    b.HasIndex("Rid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BilliardShop.Models.Order", b =>
                {
                    b.HasOne("BilliardShop.Models.PaymentMethod", "Pm")
                        .WithMany("Orders")
                        .HasForeignKey("Pmid")
                        .HasConstraintName("FK_Orders_PaymentMethod");

                    b.HasOne("BilliardShop.Models.User", "UidNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Uid")
                        .HasConstraintName("FK_Orders_Users");

                    b.Navigation("Pm");

                    b.Navigation("UidNavigation");
                });

            modelBuilder.Entity("BilliardShop.Models.OrderItem", b =>
                {
                    b.HasOne("BilliardShop.Models.Order", "OidNavigation")
                        .WithMany("OrderItems")
                        .HasForeignKey("Oid")
                        .HasConstraintName("FK_OrderItems_Orders");

                    b.HasOne("BilliardShop.Models.Product", "PidNavigation")
                        .WithMany("OrderItems")
                        .HasForeignKey("Pid")
                        .HasConstraintName("FK_OrderItems_Products");

                    b.HasOne("BilliardShop.Models.ProductSize", "Ps")
                        .WithMany("OrderItems")
                        .HasForeignKey("Psid")
                        .HasConstraintName("FK_OrderItems_ProductSize");

                    b.Navigation("OidNavigation");

                    b.Navigation("PidNavigation");

                    b.Navigation("Ps");
                });

            modelBuilder.Entity("BilliardShop.Models.Product", b =>
                {
                    b.HasOne("BilliardShop.Models.Category", "CidNavigation")
                        .WithMany("Products")
                        .HasForeignKey("Cid")
                        .HasConstraintName("FK_Products_Category");

                    b.HasOne("BilliardShop.Models.SubCategory", "Sc")
                        .WithMany("Products")
                        .HasForeignKey("Scid")
                        .HasConstraintName("FK_Products_SubCategory");

                    b.Navigation("CidNavigation");

                    b.Navigation("Sc");
                });

            modelBuilder.Entity("BilliardShop.Models.ProductImg", b =>
                {
                    b.HasOne("BilliardShop.Models.Product", "PidNavigation")
                        .WithMany("ProductImgs")
                        .HasForeignKey("Pid")
                        .HasConstraintName("FK_ProductImg_Products");

                    b.Navigation("PidNavigation");
                });

            modelBuilder.Entity("BilliardShop.Models.ProductSize", b =>
                {
                    b.HasOne("BilliardShop.Models.Product", "PidNavigation")
                        .WithMany("ProductSizes")
                        .HasForeignKey("Pid")
                        .HasConstraintName("FK_ProductSize_Products");

                    b.HasOne("BilliardShop.Models.Size", "SidNavigation")
                        .WithMany("ProductSizes")
                        .HasForeignKey("Sid")
                        .HasConstraintName("FK_ProductSize_Size");

                    b.Navigation("PidNavigation");

                    b.Navigation("SidNavigation");
                });

            modelBuilder.Entity("BilliardShop.Models.SubCategory", b =>
                {
                    b.HasOne("BilliardShop.Models.Category", "CidNavigation")
                        .WithMany("SubCategories")
                        .HasForeignKey("Cid")
                        .HasConstraintName("FK_SubCategory_Category");

                    b.Navigation("CidNavigation");
                });

            modelBuilder.Entity("BilliardShop.Models.User", b =>
                {
                    b.HasOne("BilliardShop.Models.Role", "RidNavigation")
                        .WithMany("Users")
                        .HasForeignKey("Rid")
                        .HasConstraintName("FK_Users_Role");

                    b.Navigation("RidNavigation");
                });

            modelBuilder.Entity("BilliardShop.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("BilliardShop.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BilliardShop.Models.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BilliardShop.Models.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("ProductImgs");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("BilliardShop.Models.ProductSize", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BilliardShop.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BilliardShop.Models.Size", b =>
                {
                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("BilliardShop.Models.SubCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BilliardShop.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
