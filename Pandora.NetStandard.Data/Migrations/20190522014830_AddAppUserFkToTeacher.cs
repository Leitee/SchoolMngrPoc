using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class AddAppUserFkToTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "School",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                schema: "School",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "be3d3f4a-9b79-4c98-9a22-f7b3123512c4");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f419efa1-b557-420e-92f0-9d3300e3c0fa");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "efe8ce76-006b-4c31-8941-acd7fa81efa1");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f86ba077-98af-44e7-922c-ca5e60a66f12");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "d502abd1-c1ed-4d1f-b72e-4c2c63328576");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "4ffafbba-a5db-4f17-9358-0e1c9d4f2a3b", new DateTime(2019, 5, 22, 1, 48, 29, 773, DateTimeKind.Utc).AddTicks(4450), "AQAAAAEAACcQAAAAENGcKMki70fA9f9IGUNlRIYH5R5he1QOhBTWXZrBhsfhMnnJBjJ3EcTCQyrZx21lCQ==" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 100, 0, "0eccbf53-3e1f-403f-8c21-a75228160549", "dabrown@teacher.com", true, "Dan", new DateTime(2019, 5, 22, 1, 48, 29, 781, DateTimeKind.Utc).AddTicks(5960), "Brown", false, null, "DABROWN@TEACHER.COM", "DABROWN", "AQAAAAEAACcQAAAAEFyRNXWouWQuj3t0dnd0PC9QcWjwDOe1z8VM7fksLUsIIJXoZSz7/iWK8R5AhHT8mQ==", null, false, "", false, "dabrown" });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Students",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1000, null, "atila.thehun@student.com", "Atila", "TheHun", "321987465" },
                    { 1001, null, "bruce.wayne@student.com", "Bruce", "Wayne", "321850465" },
                    { 1002, null, "milton.friedman@student.com", "Milton", "Friedman", "390987465" }
                });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Subjects",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[,]
                {
                    { 1, "Matemáticas I", null },
                    { 2, "Fisica I", null }
                });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Subjects",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 3, "Matemáticas II", 1 });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Teachers",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { 1, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ApplicationUserId",
                schema: "School",
                table: "Teachers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_ApplicationUserId",
                schema: "School",
                table: "Teachers",
                column: "ApplicationUserId",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_ApplicationUserId",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ApplicationUserId",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "School",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "School",
                table: "Teachers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "School",
                table: "Teachers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "School",
                table: "Teachers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "School",
                table: "Teachers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "School",
                table: "Teachers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "7500f333-d906-4203-9dbf-db5bba8b7ec2");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9d455f3d-ba0b-4cdb-b756-9c7ee4177305");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a1a10ada-5b93-4930-85a3-aa832c35b2e4");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e929acb3-8a85-4af3-a8d9-21869473f792");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "acd38c5e-05fd-4b74-bf4b-225413dbb629");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "a46cda2d-0ba7-4c66-9e9d-fbd884fcae7c", new DateTime(2019, 5, 22, 0, 34, 56, 170, DateTimeKind.Utc).AddTicks(2462), "AQAAAAEAACcQAAAAEJHzNoXtnfoUQbQBxYoBPrPlFp9ATN9Fh2i5mUi2iXSEZN8BdA2EFgnQc2o2igIbLA==" });
        }
    }
}
