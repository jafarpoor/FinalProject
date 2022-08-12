using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(1225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 101, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(3112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 100, DateTimeKind.Local).AddTicks(5010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(9083),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 101, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(6472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 100, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(730),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 100, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 10, DateTimeKind.Local).AddTicks(689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 85, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 30, DateTimeKind.Local).AddTicks(7609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 99, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.CreateTable(
                name: "userAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(3516)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAddresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 101, DateTimeKind.Local).AddTicks(2774),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 32, DateTimeKind.Local).AddTicks(1225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 100, DateTimeKind.Local).AddTicks(5010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 101, DateTimeKind.Local).AddTicks(719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 100, DateTimeKind.Local).AddTicks(8766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 100, DateTimeKind.Local).AddTicks(2585),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 31, DateTimeKind.Local).AddTicks(730));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 85, DateTimeKind.Local).AddTicks(2172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 10, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 4, 22, 38, 15, 99, DateTimeKind.Local).AddTicks(9580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 8, 12, 23, 5, 35, 30, DateTimeKind.Local).AddTicks(7609));
        }
    }
}
