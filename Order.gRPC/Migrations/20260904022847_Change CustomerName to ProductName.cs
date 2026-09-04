using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.gRPC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCustomerNametoProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Orders",
                newName: "ProductName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Orders",
                newName: "CustomerName");
        }
    }
}
