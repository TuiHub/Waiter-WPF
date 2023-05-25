using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waiter.Migrations
{
    /// <inheritdoc />
    public partial class AddAppBaseDir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkDir",
                table: "AppPackageSettings",
                newName: "AppWorkDir");

            migrationBuilder.AddColumn<string>(
                name: "AppBaseDir",
                table: "AppPackageSettings",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppBaseDir",
                table: "AppPackageSettings");

            migrationBuilder.RenameColumn(
                name: "AppWorkDir",
                table: "AppPackageSettings",
                newName: "WorkDir");
        }
    }
}
