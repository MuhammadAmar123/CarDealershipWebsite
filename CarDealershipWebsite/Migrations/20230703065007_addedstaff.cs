using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealershipWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addedstaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Stores_StoreId",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_StoreId",
                table: "Staffs",
                newName: "IX_Staffs_StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Stores_StoreId",
                table: "Staffs",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Stores_StoreId",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_StoreId",
                table: "Staff",
                newName: "IX_Staff_StoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Stores_StoreId",
                table: "Staff",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
