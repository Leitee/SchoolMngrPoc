using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class AddSubjectAssignament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attends_Students_StudentId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_ClassRooms_ClassRoomId",
                schema: "School",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStates_Subjects_SubjectId",
                schema: "School",
                table: "StudentStates");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentStates_SubjectId",
                schema: "School",
                table: "StudentStates");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Exams_StudentId",
                schema: "School",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassRoomId",
                schema: "School",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Attends_StudentId",
                schema: "School",
                table: "Attends");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ClassId",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                schema: "School",
                table: "Classes");

            migrationBuilder.CreateTable(
                name: "SubjectAssingments",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Disable = table.Column<bool>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    ClassRoomId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAssingments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectAssingments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "School",
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAssingments_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalSchema: "School",
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectAssingments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "School",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAssingments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "School",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssingments_ClassId",
                schema: "School",
                table: "SubjectAssingments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssingments_ClassRoomId",
                schema: "School",
                table: "SubjectAssingments",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssingments_SubjectId",
                schema: "School",
                table: "SubjectAssingments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAssingments_TeacherId",
                schema: "School",
                table: "SubjectAssingments",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectAssingments",
                schema: "School");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                schema: "School",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                schema: "School",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                schema: "School",
                table: "Classes",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                schema: "School",
                table: "Subjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStates_SubjectId",
                schema: "School",
                table: "StudentStates",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                schema: "School",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudentId",
                schema: "School",
                table: "Exams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassRoomId",
                schema: "School",
                table: "Classes",
                column: "ClassRoomId");

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
                name: "FK_Classes_ClassRooms_ClassRoomId",
                schema: "School",
                table: "Classes",
                column: "ClassRoomId",
                principalSchema: "School",
                principalTable: "ClassRooms",
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
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_StudentStates_Subjects_SubjectId",
                schema: "School",
                table: "StudentStates",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
