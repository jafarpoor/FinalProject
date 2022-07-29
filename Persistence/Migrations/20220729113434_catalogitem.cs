using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class catalogitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentIdCatalogType",
                table: "CatalogType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 225, DateTimeKind.Local).AddTicks(6807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 558, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 224, DateTimeKind.Local).AddTicks(8648),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 557, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.AddColumn<int>(
                name: "AvailableStock",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CatalogBrandId",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CatalogTypeId",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "catalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxStockThreshold",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "catalogItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestockThreshold",
                table: "catalogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 211, DateTimeKind.Local).AddTicks(144),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 530, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.CreateTable(
                name: "catalogItemFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogItemId = table.Column<int>(type: "int", nullable: true),
                    CatlogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 225, DateTimeKind.Local).AddTicks(2497)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogItemFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catalogItemFeatures_catalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "catalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "catalogItemImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogItemId = table.Column<int>(type: "int", nullable: true),
                    CatlogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 225, DateTimeKind.Local).AddTicks(4518)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catalogItemImages_catalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "catalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "BrandName", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "سامسونگ", null, null },
                    { 2, "شیائومی ", null, null },
                    { 3, "اپل", null, null },
                    { 4, "هوآوی", null, null },
                    { 5, "نوکیا ", null, null },
                    { 6, "ال جی", null, null }
                });

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentCatalogTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentCatalogTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                column: "ParentCatalogTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                column: "ParentCatalogTypeId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_catalogItems_CatalogBrandId",
                table: "catalogItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_catalogItems_CatalogTypeId",
                table: "catalogItems",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_catalogItemFeatures_CatalogItemId",
                table: "catalogItemFeatures",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_catalogItemImages_CatalogItemId",
                table: "catalogItemImages",
                column: "CatalogItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_catalogItems_CatalogBrand_CatalogBrandId",
                table: "catalogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_catalogItems_CatalogType_CatalogTypeId",
                table: "catalogItems",
                column: "CatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogItems_CatalogBrand_CatalogBrandId",
                table: "catalogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_catalogItems_CatalogType_CatalogTypeId",
                table: "catalogItems");

            migrationBuilder.DropTable(
                name: "catalogItemFeatures");

            migrationBuilder.DropTable(
                name: "catalogItemImages");

            migrationBuilder.DropIndex(
                name: "IX_catalogItems_CatalogBrandId",
                table: "catalogItems");

            migrationBuilder.DropIndex(
                name: "IX_catalogItems_CatalogTypeId",
                table: "catalogItems");

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "AvailableStock",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "CatalogBrandId",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "CatalogTypeId",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "MaxStockThreshold",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "catalogItems");

            migrationBuilder.DropColumn(
                name: "RestockThreshold",
                table: "catalogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 558, DateTimeKind.Local).AddTicks(428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 225, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.AddColumn<int>(
                name: "ParentIdCatalogType",
                table: "CatalogType",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 557, DateTimeKind.Local).AddTicks(7514),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 224, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 26, 12, 9, 31, 530, DateTimeKind.Local).AddTicks(3493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 29, 16, 4, 33, 211, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ParentCatalogTypeId", "ParentIdCatalogType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ParentCatalogTypeId", "ParentIdCatalogType" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ParentCatalogTypeId", "ParentIdCatalogType" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ParentCatalogTypeId", "ParentIdCatalogType" },
                values: new object[] { null, 2 });
        }
    }
}
