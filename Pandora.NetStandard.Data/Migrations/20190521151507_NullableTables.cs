using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class NullableTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                schema: "School",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "School",
                table: "Subjects",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                schema: "School",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "1731cb72-dfb8-4c0d-b9aa-71af5636d0ce");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c3f52b4d-46fc-460b-9392-3da10cb5d667");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "41adf60e-7aa0-4737-816b-58843ceca8fb");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0984c64e-b885-4f19-a569-68f272bc5f55");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "25d53325-520d-4731-a21e-414e941fe023");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "a4935601-9d82-4aa5-8450-0d29375f8b7c", new DateTime(2019, 5, 21, 15, 15, 7, 48, DateTimeKind.Utc).AddTicks(6678), "AQAAAAEAACcQAAAAEE/oAaoJDU0+Rjm1D7XNMi6Hu9h979E5uOIMZ7hGqUZ5ASODRTqihqJePW2Pp8+Edw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                schema: "School",
                table: "Students",
                column: "ClassId",
                principalSchema: "School",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                schema: "School",
                table: "Subjects",
                column: "TeacherId",
                principalSchema: "School",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                schema: "School",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "School",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                schema: "School",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "2c653a2a-a8e6-48e5-b312-86cbe71d6c05");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "534acead-798b-47bc-8d9a-41d8ab5df837");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9eb19c71-ef7c-4fb9-8f72-e128e8f85d04");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "25ea9eab-c518-4b3c-959f-bc88f0706373");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "58d6bb59-6a5c-46ef-87d4-59f49353eb54");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "c05135bd-5275-42cd-bc99-34356ea7f545", new DateTime(2019, 5, 13, 20, 18, 35, 862, DateTimeKind.Utc).AddTicks(2396), "AQAAAAEAACcQAAAAEJZe9G1ctyLdiVQLyVQT4lGrAO0thRdMRzpMZmxK/JXlpSeca/um+galTdRbaju/sQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                schema: "School",
                table: "Students",
                column: "ClassId",
                principalSchema: "School",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                schema: "School",
                table: "Subjects",
                column: "TeacherId",
                principalSchema: "School",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
