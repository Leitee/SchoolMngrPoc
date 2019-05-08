using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class AddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityCode = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    ClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "School",
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "d44fb4f9-a8b6-409d-9329-2e69f36fc202");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e57e4a27-931c-4e6d-b097-6b7efec307d4");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "682aac90-9152-4784-8b22-87af67db1b1a");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "47d7b938-8b5f-4c7e-98cc-326635132e54");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "5d2dbd2a-806f-41ee-8ff6-d73231b13580", new DateTime(2019, 5, 8, 14, 33, 51, 473, DateTimeKind.Utc).AddTicks(8628), "AQAAAAEAACcQAAAAEAW39ogz8noQdOXX1sLdsS+QgCVP819gZn1WLqHfnLkAwc6n+bsItN800WNM684uAw==" });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "1er");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                schema: "School",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students",
                schema: "School");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "3673eea3-fd15-4b34-b6e1-3fa4592cd5c9");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c17e9d8c-5d70-455a-88a7-2f64c27d44f9");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9024bfe1-368b-45ce-98a4-e349efdfa718");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c6c49ded-5da4-4ccd-bdd2-2f6be44068e8");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "111e1652-566f-4008-91ca-1047fa2e4d89", new DateTime(2019, 4, 8, 2, 0, 32, 462, DateTimeKind.Utc).AddTicks(3675), "AQAAAAEAACcQAAAAEPOlC1DqxEu6oOBpbuxdMcMb3Gu+s3aCpygJbmXiJTTsLCMN5QIsldK5HFVnVO0kyA==" });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "1ro");
        }
    }
}
