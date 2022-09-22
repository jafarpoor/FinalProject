using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class sortby1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 916, DateTimeKind.Local).AddTicks(8098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 916, DateTimeKind.Local).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 915, DateTimeKind.Local).AddTicks(8139),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 916, DateTimeKind.Local).AddTicks(2684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 915, DateTimeKind.Local).AddTicks(3217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(9077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 913, DateTimeKind.Local).AddTicks(4296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(5914),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(7343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(2883),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 913, DateTimeKind.Local).AddTicks(179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 894, DateTimeKind.Local).AddTicks(8863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 584, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 912, DateTimeKind.Local).AddTicks(6662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(4185));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "catalogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(3925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 916, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 595, DateTimeKind.Local).AddTicks(2050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 916, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(6118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 915, DateTimeKind.Local).AddTicks(8139));

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
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 916, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 594, DateTimeKind.Local).AddTicks(2184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 915, DateTimeKind.Local).AddTicks(3217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(9386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(9435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 913, DateTimeKind.Local).AddTicks(4296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(7343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(5281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFavourites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 593, DateTimeKind.Local).AddTicks(3387),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 914, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(6558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 913, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 584, DateTimeKind.Local).AddTicks(7288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 894, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 22, 9, 15, 48, 592, DateTimeKind.Local).AddTicks(4185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 22, 10, 35, 49, 912, DateTimeKind.Local).AddTicks(6662));
        }
    }
}
