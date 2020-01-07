using Microsoft.EntityFrameworkCore.Migrations;

namespace Cloud_System_dev_ops.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "ReSale");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReSale",
                table: "ReSale",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReSale",
                table: "ReSale");

            migrationBuilder.RenameTable(
                name: "ReSale",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ProductId");
        }
    }
}
