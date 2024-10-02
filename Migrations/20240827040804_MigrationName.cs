using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilliardShop.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    bid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    des = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.bid);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    blid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bldtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blcontent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    createdate = table.Column<DateTime>(type: "date", nullable: true),
                    blimage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.blid);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.cid);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    pmid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pmname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    pmdes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.pmid);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    rid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.rid);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.sid);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    scid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    scname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.scid);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category",
                        column: x => x.cid,
                        principalTable: "Category",
                        principalColumn: "cid");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    upass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uid);
                    table.ForeignKey(
                        name: "FK_Users_Role",
                        column: x => x.rid,
                        principalTable: "Role",
                        principalColumn: "rid");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    pid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    pdes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true),
                    cid = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    scid = table.Column<int>(type: "int", nullable: true),
                    datecreate = table.Column<DateTime>(type: "date", nullable: true),
                    capitalprice = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.pid);
                    table.ForeignKey(
                        name: "FK_Products_Category",
                        column: x => x.cid,
                        principalTable: "Category",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK_Products_SubCategory",
                        column: x => x.scid,
                        principalTable: "SubCategory",
                        principalColumn: "scid");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    oid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<int>(type: "int", nullable: true),
                    totalamount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderdate = table.Column<DateTime>(type: "date", nullable: true),
                    pmid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.oid);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethod",
                        column: x => x.pmid,
                        principalTable: "PaymentMethod",
                        principalColumn: "pmid");
                    table.ForeignKey(
                        name: "FK_Orders_Users",
                        column: x => x.uid,
                        principalTable: "Users",
                        principalColumn: "uid");
                });

            migrationBuilder.CreateTable(
                name: "ProductImg",
                columns: table => new
                {
                    pimgid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImg", x => x.pimgid);
                    table.ForeignKey(
                        name: "FK_ProductImg_Products",
                        column: x => x.pid,
                        principalTable: "Products",
                        principalColumn: "pid");
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    psid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sid = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.psid);
                    table.ForeignKey(
                        name: "FK_ProductSize_Products",
                        column: x => x.pid,
                        principalTable: "Products",
                        principalColumn: "pid");
                    table.ForeignKey(
                        name: "FK_ProductSize_Size",
                        column: x => x.sid,
                        principalTable: "Size",
                        principalColumn: "sid");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    otid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oid = table.Column<int>(type: "int", nullable: true),
                    pid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    psid = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.otid);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders",
                        column: x => x.oid,
                        principalTable: "Orders",
                        principalColumn: "oid");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products",
                        column: x => x.pid,
                        principalTable: "Products",
                        principalColumn: "pid");
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductSize",
                        column: x => x.psid,
                        principalTable: "ProductSize",
                        principalColumn: "psid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_oid",
                table: "OrderItems",
                column: "oid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_pid",
                table: "OrderItems",
                column: "pid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_psid",
                table: "OrderItems",
                column: "psid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_pmid",
                table: "Orders",
                column: "pmid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_uid",
                table: "Orders",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImg_pid",
                table: "ProductImg",
                column: "pid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_cid",
                table: "Products",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_scid",
                table: "Products",
                column: "scid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_pid",
                table: "ProductSize",
                column: "pid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_sid",
                table: "ProductSize",
                column: "sid");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_cid",
                table: "SubCategory",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_rid",
                table: "Users",
                column: "rid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImg");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
