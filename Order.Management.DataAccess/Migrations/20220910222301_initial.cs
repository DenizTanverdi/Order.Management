using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Management.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfDeletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "CreationDate", "DateOfDeletion", "IsActive", "Password", "Username" },
                values: new object[] { 1, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(6805), null, 1, "Q1w2E3s", "admin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreationDate", "DateOfDeletion", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Arnavutköy", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(6973), null, 1, "Deniz Tanriverdi" },
                    { 2, "Esenler", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(6975), null, 1, "Ali Tanriverdi" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CreationDate", "DateOfDeletion", "Description", "IsActive", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "123456780", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7293), null, "Tablet", 1, 1000m, 1.0 },
                    { 2, "123456781", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7294), null, "Bilgisayar", 1, 9000m, 1.0 },
                    { 3, "123456782", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7295), null, "Telefon", 1, 4000m, 1.0 },
                    { 4, "123456780", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7296), null, "Tablet", 1, 1000m, 1.0 },
                    { 5, "123456781", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7297), null, "Bilgisayar", 1, 9000m, 1.0 },
                    { 6, "123456782", new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7298), null, "Telefon", 1, 4000m, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreationDate", "CustomerId", "DateOfDeletion", "IsActive", "OrderAddress" },
                values: new object[] { 1, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7197), 1, null, 1, "Sultangazi" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreationDate", "CustomerId", "DateOfDeletion", "IsActive", "OrderAddress" },
                values: new object[] { 2, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7199), 2, null, 1, "Arnavutköy" });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "CreationDate", "DateOfDeletion", "Id", "IsActive", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7061), null, 1, 1, 1.0 },
                    { 1, 2, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7063), null, 2, 1, 2.0 },
                    { 1, 3, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7064), null, 3, 1, 3.0 },
                    { 2, 1, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7065), null, 4, 1, 1.0 },
                    { 2, 2, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7065), null, 5, 1, 1.0 },
                    { 2, 3, new DateTime(2022, 9, 11, 2, 23, 1, 378, DateTimeKind.Local).AddTicks(7066), null, 6, 1, 2.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
