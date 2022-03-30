using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorMachineTest.Data.Migrations
{
    public partial class initial_bd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineCurrency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceRequested = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineCurrencyId = table.Column<int>(type: "int", nullable: false),
                    MachineLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_MachineCurrency_MachineCurrencyId",
                        column: x => x.MachineCurrencyId,
                        principalTable: "MachineCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_MachineLanguage_MachineLanguageId",
                        column: x => x.MachineLanguageId,
                        principalTable: "MachineLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MachineSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlotName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineSlots_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineSlots_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MachineCurrency",
                columns: new[] { "Id", "CreatedOn", "Currency" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "EUR" },
                    { 2, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "USD" }
                });

            migrationBuilder.InsertData(
                table: "MachineLanguage",
                columns: new[] { "Id", "CreatedOn", "Language" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "EN" },
                    { 2, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "DE" },
                    { 3, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "FR" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreatedOn", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "Coca Cola", "COLA", 1m },
                    { 2, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "Chips", "Chips", 0.5m },
                    { 3, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), "Candy", "Candy", 1.65m }
                });

            migrationBuilder.InsertData(
                table: "Machine",
                columns: new[] { "Id", "CreatedOn", "MachineCurrencyId", "MachineLanguageId", "MaintenanceRequested" },
                values: new object[] { 1, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, 1, false });

            migrationBuilder.InsertData(
                table: "ProductStock",
                columns: new[] { "Id", "CreatedOn", "ProductId", "Quantidade" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, 8 },
                    { 2, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 2, 12 },
                    { 3, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "MachineSlots",
                columns: new[] { "Id", "CreatedOn", "MachineId", "ProductId", "SlotName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, 1, "Slot 1" },
                    { 2, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, 2, "Slot 2" },
                    { 3, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, 3, "Slot 3" },
                    { 4, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, null, "Slot 4" },
                    { 5, new DateTime(2022, 3, 30, 19, 33, 21, 881, DateTimeKind.Utc).AddTicks(616), 1, null, "Slot 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineCurrencyId",
                table: "Machine",
                column: "MachineCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineLanguageId",
                table: "Machine",
                column: "MachineLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSlots_MachineId",
                table: "MachineSlots",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSlots_ProductId",
                table: "MachineSlots",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineSlots");

            migrationBuilder.DropTable(
                name: "ProductStock");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "MachineCurrency");

            migrationBuilder.DropTable(
                name: "MachineLanguage");
        }
    }
}
