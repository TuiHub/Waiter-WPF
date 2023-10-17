using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waiter.Migrations
{
    /// <inheritdoc />
    public partial class AddUseProcListenMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseProcListenMode",
                table: "AppPackageSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseProcListenMode",
                table: "AppPackageSettings");
        }
    }
}
