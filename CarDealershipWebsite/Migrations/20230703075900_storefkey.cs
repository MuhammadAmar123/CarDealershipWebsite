using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipWebsite.Migrations
{
    /// <inheritdoc />
    public partial class storefkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsStocks_Stores_StorelId",
                table: "CarsStocks");

            migrationBuilder.DropIndex(
                name: "IX_CarsStocks_StorelId",
                table: "CarsStocks");

            migrationBuilder.DropColumn(
                name: "StorelId",
                table: "CarsStocks");

            migrationBuilder.CreateIndex(
                name: "IX_CarsStocks_StoreId",
                table: "CarsStocks",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsStocks_Stores_StoreId",
                table: "CarsStocks",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsStocks_Stores_StoreId",
                table: "CarsStocks");

            migrationBuilder.DropIndex(
                name: "IX_CarsStocks_StoreId",
                table: "CarsStocks");

            migrationBuilder.AddColumn<int>(
                name: "StorelId",
                table: "CarsStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CarsStocks_StorelId",
                table: "CarsStocks",
                column: "StorelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsStocks_Stores_StorelId",
                table: "CarsStocks",
                column: "StorelId",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
