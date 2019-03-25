using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class setSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "School");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grades",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Classes",
                newSchema: "School");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Grades",
                schema: "School",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "Classes",
                schema: "School",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Auth",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "Auth",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Auth",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Auth",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Auth",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Auth",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Auth",
                newName: "RoleClaims");
        }
    }
}
