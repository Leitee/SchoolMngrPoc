using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class IdentitySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { -1, "3673eea3-fd15-4b34-b6e1-3fa4592cd5c9", "Full functionality over app and debugin", "Dev", "DEV" },
                    { 1, "c17e9d8c-5d70-455a-88a7-2f64c27d44f9", "Full permissions and features", "Admin", "ADMIN" },
                    { 2, "9024bfe1-368b-45ce-98a4-e349efdfa718", "Limited functionality just administrative permissions", "Super", "SUPER" },
                    { 3, "c6c49ded-5da4-4ccd-bdd2-2f6be44068e8", "Limited functionality just teaching-relative permissions", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { -1, 0, "111e1652-566f-4008-91ca-1047fa2e4d89", "info@pandorasistemas.com", true, "Jhon", new DateTime(2019, 4, 8, 2, 0, 32, 462, DateTimeKind.Utc).AddTicks(3675), "Doe", false, null, "INFO@PANDORASISTEMAS.COM", "DEVADMIN", "AQAAAAEAACcQAAAAEPOlC1DqxEu6oOBpbuxdMcMb3Gu+s3aCpygJbmXiJTTsLCMN5QIsldK5HFVnVO0kyA==", null, false, "", false, "devadmin" });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Grades",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1ro" },
                    { 2, "2do" },
                    { 3, "3ro" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { -1, -1 });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Classes",
                columns: new[] { "Id", "GradeId", "Name", "Shift" },
                values: new object[,]
                {
                    { 1, 1, "1ra", 1 },
                    { 2, 1, "2da", 2 },
                    { 3, 1, "3ra", 3 },
                    { 4, 2, "1ra", 1 },
                    { 5, 2, "2da", 2 },
                    { 6, 3, "1ra", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
