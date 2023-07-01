using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipWebsite.Migrations
{
    /// <inheritdoc />
    public partial class fkeyadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_CarsStocks_StockID",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Sales_SaleID",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerID",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Stores_StoreID",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "Staff",
                newName: "StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_StoreID",
                table: "Staff",
                newName: "IX_Staff_StoreId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Sales",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CustomerID",
                table: "Sales",
                newName: "IX_Sales_CustomerId");

            migrationBuilder.RenameColumn(
                name: "SaleID",
                table: "SaleItems",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "StockID",
                table: "SaleItems",
                newName: "CarsStockId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_SaleID",
                table: "SaleItems",
                newName: "IX_SaleItems_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_StockID",
                table: "SaleItems",
                newName: "IX_SaleItems_CarsStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_CarsStocks_CarsStockId",
                table: "SaleItems",
                column: "CarsStockId",
                principalTable: "CarsStocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Sales_SaleId",
                table: "SaleItems",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Stores_StoreId",
                table: "Staff",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_CarsStocks_CarsStockId",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Sales_SaleId",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Stores_StoreId",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Staff",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_StoreId",
                table: "Staff",
                newName: "IX_Staff_StoreID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Sales",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                newName: "IX_Sales_CustomerID");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "SaleItems",
                newName: "SaleID");

            migrationBuilder.RenameColumn(
                name: "CarsStockId",
                table: "SaleItems",
                newName: "StockID");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_SaleId",
                table: "SaleItems",
                newName: "IX_SaleItems_SaleID");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_CarsStockId",
                table: "SaleItems",
                newName: "IX_SaleItems_StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_CarsStocks_StockID",
                table: "SaleItems",
                column: "StockID",
                principalTable: "CarsStocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Sales_SaleID",
                table: "SaleItems",
                column: "SaleID",
                principalTable: "Sales",
                principalColumn: "SaleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerID",
                table: "Sales",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Stores_StoreID",
                table: "Staff",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
