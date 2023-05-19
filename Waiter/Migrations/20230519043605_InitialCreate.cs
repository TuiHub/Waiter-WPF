using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waiter.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPackageSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppPackageId = table.Column<long>(type: "INTEGER", nullable: false),
                    AppPath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    WorkDir = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ProcMonName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ProcMonPath = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPackageSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccessToken = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    RefreshToken = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPackageSettings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
