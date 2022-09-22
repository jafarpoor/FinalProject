using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class sortby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(3925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 197, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(2050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 197, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(6118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 195, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(9795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 196, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(2184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 193, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(9386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 127, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(9435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 126, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(7343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 127, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(5281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 127, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(3387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 126, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(6558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 125, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 584, DateTimeKind.Local).AddTicks(7288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 112, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(4185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 125, DateTimeKind.Local).AddTicks(2637));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 197, DateTimeKind.Local).AddTicks(8472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 197, DateTimeKind.Local).AddTicks(2227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 195, DateTimeKind.Local).AddTicks(2769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 196, DateTimeKind.Local).AddTicks(4394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 193, DateTimeKind.Local).AddTicks(9861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 127, DateTimeKind.Local).AddTicks(9318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 126, DateTimeKind.Local).AddTicks(1684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 127, DateTimeKind.Local).AddTicks(5422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 127, DateTimeKind.Local).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 126, DateTimeKind.Local).AddTicks(8690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 125, DateTimeKind.Local).AddTicks(6714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 112, DateTimeKind.Local).AddTicks(4473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 584, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 11, 23, 59, 125, DateTimeKind.Local).AddTicks(2637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(4185));
        }
    }
}
