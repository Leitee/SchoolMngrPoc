using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pandora.NetStandard.Data.Migrations
{
    public partial class SubjectStudentRelat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "School",
                table: "Teachers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                schema: "School",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "School",
                table: "Students",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassRoomId",
                schema: "School",
                table: "Classes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attends",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attendance = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Obs = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attends_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "School",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attends_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "School",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassRooms",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Capacity = table.Column<short>(nullable: false),
                    HasNetworkConexioin = table.Column<bool>(nullable: true),
                    HasScreenProjector = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentStates",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicState = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Obs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentStates_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "School",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStates_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "School",
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { 4, "334e91bb-02f2-4895-bca9-353d5b7f753a", "Limited functionality just student-relative permissions", "Student", "STUDENT" });

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "0c4fbc14-cbde-4a06-8f16-582d2a53322e", new DateTime(2019, 5, 10, 5, 38, 2, 918, DateTimeKind.Utc).AddTicks(2551), "AQAAAAEAACcQAAAAEOXa1uFw6rYaJ18P6fAqZ4rpB3BdrDrcR0Ai7ygcOVCkcMcFK8WfmOGzITkHmI4Zew==" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectId",
                schema: "School",
                table: "Subjects",
                column: "SubjectId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Attends_SubjectId",
                schema: "School",
                table: "Attends",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStates_StudentId",
                schema: "School",
                table: "StudentStates",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStates_SubjectId",
                schema: "School",
                table: "StudentStates",
                column: "SubjectId");

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
                name: "FK_Subjects_Subjects_SubjectId",
                schema: "School",
                table: "Subjects",
                column: "SubjectId",
                principalSchema: "School",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_ClassRooms_ClassRoomId",
                schema: "School",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Subjects_SubjectId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Attends",
                schema: "School");

            migrationBuilder.DropTable(
                name: "ClassRooms",
                schema: "School");

            migrationBuilder.DropTable(
                name: "StudentStates",
                schema: "School");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SubjectId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Classes_ClassRoomId",
                schema: "School",
                table: "Classes");

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "School",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                schema: "School",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassRoomId",
                schema: "School",
                table: "Classes");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "bb85c4d2-8e06-496d-87e4-3d9945ed489e");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f00fc888-f013-4262-b26e-9e828b78d7bd");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6133dff7-9c65-49bc-aa2c-e1f65a7aa935");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5d92e7d7-0e70-4f1f-a82d-13ea8274d028");

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "ConcurrencyStamp", "JoinDate", "PasswordHash" },
                values: new object[] { "4ae6e4fd-8060-488d-807b-3b35b17693a5", new DateTime(2019, 5, 9, 3, 18, 13, 562, DateTimeKind.Utc).AddTicks(5226), "AQAAAAEAACcQAAAAEEv1jpiIzb477co1YPlEBrAFpbguHFl1oujbtbYyKb2SkGs9mSA5ujNlkkqK1F1ACA==" });
        }
    }
}
