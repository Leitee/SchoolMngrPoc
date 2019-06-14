using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class studentRelatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "School",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "HasNetworkConexioin",
                schema: "School",
                table: "ClassRooms",
                newName: "HasNetworkConexion");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "School",
                table: "Teachers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Obs",
                schema: "School",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                schema: "School",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Obs",
                schema: "School",
                table: "Students",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "79c59c9c-1e31-4017-9b62-33b350f7bcca");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d13452da-7fb7-41a1-833d-7104e228f62f");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c2233b8f-2bed-478d-9e97-845de7d0e404");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "49c207c7-6a13-48f9-9b4f-b3a8261cea49");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "ff1e828a-6434-458d-9d94-78a7e32215e3");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "a1637585-1120-46bc-8937-0bdef470e839", new DateTime(2019, 6, 14, 2, 50, 26, 4, DateTimeKind.Utc).AddTicks(4287), "AQAAAAEAACcQAAAAELQRDSDYGKOTHvwK+yh4E6jpZLWdMHO6xbbzNrTzq61hS9Yp9tkF/bO4lzYM/1TeLQ==" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinDate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 102, 0, "45f5145a-4cfd-4030-871e-4ed5642bfafc", "ayn.rand@student.com", true, "Ayn", new DateTime(2019, 6, 14, 2, 50, 26, 27, DateTimeKind.Utc).AddTicks(3120), "Rand", false, null, "AYN.RAND@STUDENT.COM", "ANRAND", "AQAAAAEAACcQAAAAEChA1GDqX91r8IVoxat7u49wCwCx71n3UbqOMWe+3kzTOZPrQUDLR7JprrzGNKxmkg==", null, false, "", false, "anrand" },
                    { 101, 0, "2703a81e-1c04-4897-9e09-8e6c955e678a", "bruce.wayne@student.com", true, "Bruce", new DateTime(2019, 6, 14, 2, 50, 26, 22, DateTimeKind.Utc).AddTicks(3233), "Wayne", false, null, "BRUCE.WAYNE@STUDENT.COM", "BRWAYNE", "AQAAAAEAACcQAAAAEFcYsRnUEcreRtrC/NykXTrigDvxMNJ2eiaM805KGJzbNXpnxjLZhn1Y+OIc8au/pg==", null, false, "", false, "brwayne" },
                    { 103, 0, "01c5f351-bcdf-49e4-bd16-fc8b09b09b1e", "milton.friedman@student.com", true, "Milton", new DateTime(2019, 6, 14, 2, 50, 26, 32, DateTimeKind.Utc).AddTicks(2738), "Fiedman", false, null, "MILTON.FRIEDMAN@STUDENT.COM", "MIFRIEDMAN", "AQAAAAEAACcQAAAAEITCaGTYRyNkrNndG6k6Pd4T4ACE64Drt/DiJKBaovQ1xohNw0n1nPjc9etRt7FQPQ==", null, false, "", false, "mifriedman" },
                    { 1, 0, "1645d07f-7cfe-4b07-989f-a105c434aca6", "risanchez@admin.com", true, "Rick", new DateTime(2019, 6, 14, 2, 50, 26, 12, DateTimeKind.Utc).AddTicks(3500), "Sanchez", false, null, "RISANCHEZ@ADMIN.COM", "RISANCHEZ", "AQAAAAEAACcQAAAAEJQEXGcv6K/sqzcmGiAtRAe4POZ+mSIFVn+inn7w73zWKHYZe0Akb4dAtvT+AMD54Q==", null, false, "", false, "risanchez" },
                    { 11, 0, "3e097363-070a-4927-bff6-87d3d5422b76", "dabrown@teacher.com", true, "Dan", new DateTime(2019, 6, 14, 2, 50, 26, 17, DateTimeKind.Utc).AddTicks(3532), "Brown", false, null, "DABROWN@TEACHER.COM", "DABROWN", "AQAAAAEAACcQAAAAEIAQxKyMzjQvxx9tWdkk2RkjkLxmDW0gEHQLDTzgws+bxsmj6SBJU+cbPIxRFYARMw==", null, false, "", false, "dabrown" }
                });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GradeId", "Name", "Shift" },
                values: new object[] { 2, "1ra", 1 });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Shift" },
                values: new object[] { "2da", 3 });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GradeId", "Name" },
                values: new object[] { 3, "1ra" });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "2da");

            migrationBuilder.InsertData(
                schema: "School",
                table: "Grades",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "4to" },
                    { 5, "5to" }
                });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Matemáticas");

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Fisica");

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SubjectId" },
                values: new object[] { "Redes", null });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Subjects",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 4, "Algoritmos", null });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 11, 3 },
                    { 101, 4 },
                    { 102, 4 },
                    { 103, 4 }
                });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Classes",
                columns: new[] { "Id", "GradeId", "Name", "Shift" },
                values: new object[,]
                {
                    { 7, 4, "1ra", 1 },
                    { 8, 5, "1ra", 1 }
                });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Students",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Obs" },
                values: new object[,]
                {
                    { 11111111, null, 101, null },
                    { 22222222, null, 102, null },
                    { 33333333, null, 103, null }
                });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Subjects",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[] { 5, "Programación", 4 });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Teachers",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Obs" },
                values: new object[] { 32165498, null, 11, null });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                schema: "School",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_ApplicationUserId",
                schema: "School",
                table: "Students",
                column: "ApplicationUserId",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_ApplicationUserId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                schema: "School",
                table: "Students");

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 101, 4 });

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 102, 4 });

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 103, 4 });

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Students",
                keyColumn: "Id",
                keyValue: 11111111);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Students",
                keyColumn: "Id",
                keyValue: 22222222);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Students",
                keyColumn: "Id",
                keyValue: 33333333);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 32165498);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Obs",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Obs",
                schema: "School",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "HasNetworkConexion",
                schema: "School",
                table: "ClassRooms",
                newName: "HasNetworkConexioin");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "School",
                table: "Students",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "School",
                table: "Students",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "School",
                table: "Students",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "School",
                table: "Students",
                maxLength: 100,
                nullable: true);

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

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GradeId", "Name", "Shift" },
                values: new object[] { 1, "3ra", 3 });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Shift" },
                values: new object[] { "1ra", 1 });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GradeId", "Name" },
                values: new object[] { 2, "2da" });

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "1ra");

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

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Matemáticas I");

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Fisica I");

            migrationBuilder.UpdateData(
                schema: "School",
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SubjectId" },
                values: new object[] { "Matemáticas II", 1 });

            migrationBuilder.InsertData(
                schema: "School",
                table: "Teachers",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { 1, 100 });
        }
    }
}
