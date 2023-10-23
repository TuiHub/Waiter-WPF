using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waiter.Migrations
{
    /// <inheritdoc />
    public partial class AddUseShellExecuteToAppPackageSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseShellExecute",
                table: "AppPackageSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseShellExecute",
                table: "AppPackageSettings");
        }
    }
}
