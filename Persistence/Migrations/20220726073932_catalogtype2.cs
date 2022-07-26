using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class catalogtype2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "CatalogType",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 558, DateTimeKind.Local).AddTicks(428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "catalogItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 557, DateTimeKind.Local).AddTicks(7514),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "CatalogBrand",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 530, DateTimeKind.Local).AddTicks(3493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTypeId", "ParentIdCatalogType", "RemoveTime", "TypeName", "UpdateTime" },
                values: new object[,]
                {
                    { 1, null, null, null, "کالای دیجیتال", null },
                    { 2, null, 1, null, "لوازم جانبی گوشی", null },
                    { 3, null, 2, null, "پایه نگهدارنده گوشی", null },
                    { 4, null, 2, null, "پاور بانک (شارژر همراه)", null },
                    { 5, null, 2, null, "کیف و کاور گوشی", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "CatalogType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 558, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "catalogItems",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 557, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "CatalogBrand",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 530, DateTimeKind.Local).AddTicks(3493));
        }
    }
}
