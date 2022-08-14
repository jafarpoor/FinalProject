using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 508, DateTimeKind.Local).AddTicks(9212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 508, DateTimeKind.Local).AddTicks(1482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(3308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(9311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(7179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 489, DateTimeKind.Local).AddTicks(3060),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 10, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 506, DateTimeKind.Local).AddTicks(7505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 30, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 508, DateTimeKind.Local).AddTicks(4174)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogItemId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 508, DateTimeKind.Local).AddTicks(6862)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_catalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "catalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_CatalogItemId",
                table: "orderItems",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(3516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 508, DateTimeKind.Local).AddTicks(9212));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(1225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 508, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(3112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(9083),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(6472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 507, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 10, DateTimeKind.Local).AddTicks(689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 489, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 30, DateTimeKind.Local).AddTicks(7609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 14, 20, 48, 21, 506, DateTimeKind.Local).AddTicks(7505));
        }
    }
}
