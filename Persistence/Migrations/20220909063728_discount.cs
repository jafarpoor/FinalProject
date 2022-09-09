using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 518, DateTimeKind.Local).AddTicks(4031),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 693, DateTimeKind.Local).AddTicks(6497));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 518, DateTimeKind.Local).AddTicks(2029),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 693, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(6409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 692, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(9456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 693, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(1368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 692, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 516, DateTimeKind.Local).AddTicks(2674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 690, DateTimeKind.Local).AddTicks(4097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 516, DateTimeKind.Local).AddTicks(8985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 691, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 516, DateTimeKind.Local).AddTicks(6889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 691, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 515, DateTimeKind.Local).AddTicks(7433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 689, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 507, DateTimeKind.Local).AddTicks(9199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 669, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 515, DateTimeKind.Local).AddTicks(3673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 689, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsePercentage = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiresCouponCode = table.Column<bool>(type: "bit", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    LimitationTimes = table.Column<int>(type: "int", nullable: false),
                    DiscountLimitationId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(3928)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemDiscount",
                columns: table => new
                {
                    CatalogItemsId = table.Column<int>(type: "int", nullable: false),
                    DiscountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemDiscount", x => new { x.CatalogItemsId, x.DiscountsId });
                    table.ForeignKey(
                        name: "FK_CatalogItemDiscount_catalogItems_CatalogItemsId",
                        column: x => x.CatalogItemsId,
                        principalTable: "catalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItemDiscount_discounts_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemDiscount_DiscountsId",
                table: "CatalogItemDiscount",
                column: "DiscountsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItemDiscount");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "userAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 693, DateTimeKind.Local).AddTicks(6497),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 518, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 693, DateTimeKind.Local).AddTicks(3570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 518, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 692, DateTimeKind.Local).AddTicks(5422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(6409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "orderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 693, DateTimeKind.Local).AddTicks(211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 692, DateTimeKind.Local).AddTicks(620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 517, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 690, DateTimeKind.Local).AddTicks(4097),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 516, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 691, DateTimeKind.Local).AddTicks(5958),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 516, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "catalogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 691, DateTimeKind.Local).AddTicks(1431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 516, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 689, DateTimeKind.Local).AddTicks(8296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 515, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 669, DateTimeKind.Local).AddTicks(1884),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 507, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "basketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 7, 23, 14, 46, 689, DateTimeKind.Local).AddTicks(2158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 9, 11, 7, 27, 515, DateTimeKind.Local).AddTicks(3673));
        }
    }
}
