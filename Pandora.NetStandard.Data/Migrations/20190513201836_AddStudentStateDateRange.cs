using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class AddStudentStateDateRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropForeignKey(
                name: "FK_Attends_Subjects_SubjectId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Subjects_SubjectId",
                schema: "School",
                table: "Exams");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                schema: "School",
                table: "StudentStates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                schema: "School",
                table: "StudentStates",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                schema: "School",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                schema: "School",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                schema: "School",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                schema: "School",
                table: "Attends",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                schema: "School",
                table: "Attends",
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
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends",
                column: "StudentId",
                principalSchema: "School",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attends_Subjects_SubjectId",
                schema: "School",
                table: "Attends",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
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
                name: "FK_Exams_Subjects_SubjectId",
                schema: "School",
                table: "Exams",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropForeignKey(
                name: "FK_Attends_Subjects_SubjectId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Subjects_SubjectId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                schema: "School",
                table: "StudentStates");

            migrationBuilder.DropColumn(
                name: "DateTo",
                schema: "School",
                table: "StudentStates");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                schema: "School",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                schema: "School",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                schema: "School",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                schema: "School",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                schema: "School",
                table: "Attends",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                schema: "School",
                table: "Attends",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "55b4df50-5144-4279-8c69-d87ec216370b");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "51128d2d-1d82-48bf-8c89-d92054417d5c");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0d4b2b59-7a13-48ec-a9e6-21d138df205b");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "336a0a77-dff2-4dc9-ba80-15abaeecde0b");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "334e91bb-02f2-4895-bca9-353d5b7f753a");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "0c4fbc14-cbde-4a06-8f16-582d2a53322e", new DateTime(2019, 5, 10, 5, 38, 2, 918, DateTimeKind.Utc).AddTicks(2551), "AQAAAAEAACcQAAAAEOXa1uFw6rYaJ18P6fAqZ4rpB3BdrDrcR0Ai7ygcOVCkcMcFK8WfmOGzITkHmI4Zew==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends",
                column: "StudentId",
                principalSchema: "School",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attends_Subjects_SubjectId",
                schema: "School",
                table: "Attends",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudentId",
                schema: "School",
                table: "Exams",
                column: "StudentId",
                principalSchema: "School",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Subjects_SubjectId",
                schema: "School",
                table: "Exams",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
