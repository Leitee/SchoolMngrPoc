using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class AddStudFks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_StudentStates_SubjectId",
                schema: "School",
                table: "StudentStates",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentId",
                schema: "School",
                table: "Exams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attends_StudentId",
                schema: "School",
                table: "Attends",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends",
                column: "StudentId",
                principalSchema: "School",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudentId",
                schema: "School",
                table: "Exams",
                column: "StudentId",
                principalSchema: "School",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStates_Subjects_SubjectId",
                schema: "School",
                table: "StudentStates",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStates_Subjects_SubjectId",
                schema: "School",
                table: "StudentStates");

            migrationBuilder.DropIndex(
                name: "IX_StudentStates_SubjectId",
                schema: "School",
                table: "StudentStates");

            migrationBuilder.DropIndex(
                name: "IX_Exams_StudentId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Attends_StudentId",
                schema: "School",
                table: "Attends");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "f8fd2a09-5bd5-46ce-b844-2ed9eea88ba6");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ba3490e2-1e93-49bf-9133-b131c38ed090");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2a30e87f-f325-4df6-a950-055658ccf18c");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "104ad33a-f0ec-4da8-b00a-db2f741a5f8c");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "92d8afeb-0199-4d38-a2a4-05ff190849f8");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "636dea41-3f2a-4b67-ada3-7aed3006c09d", new DateTime(2019, 5, 22, 0, 24, 10, 546, DateTimeKind.Utc).AddTicks(442), "AQAAAAEAACcQAAAAEG2RoREOCUjz2cWpJrmNpYYUOwCBmvfGIOOtChYuxGl/b5CWruAFdcvty3bYTqg8Kw==" });
        }
    }
}
