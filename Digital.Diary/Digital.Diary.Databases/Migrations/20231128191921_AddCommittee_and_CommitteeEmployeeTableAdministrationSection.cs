using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddCommittee_and_CommitteeEmployeeTableAdministrationSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersFaculty_Faculty_FacultyId",
                table: "TeachersFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersFaculty_Teacher_TeacherId",
                table: "TeachersFaculty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersFaculty",
                table: "TeachersFaculty");

            migrationBuilder.EnsureSchema(
                name: "Administration.Committees");

            migrationBuilder.RenameTable(
                name: "TeachersFaculty",
                newName: "TeacherFaculty",
                newSchema: "Academic");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersFaculty_TeacherId",
                schema: "Academic",
                table: "TeacherFaculty",
                newName: "IX_TeacherFaculty_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersFaculty_FacultyId",
                schema: "Academic",
                table: "TeacherFaculty",
                newName: "IX_TeacherFaculty_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherFaculty",
                schema: "Academic",
                table: "TeacherFaculty",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Committee",
                schema: "Administration.Committees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommitteeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeEmployee",
                schema: "Administration.Committees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommitteeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeEmployee_Committee_CommitteeId",
                        column: x => x.CommitteeId,
                        principalSchema: "Administration.Committees",
                        principalTable: "Committee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeEmployee_CommitteeId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                column: "CommitteeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherFaculty_Faculty_FacultyId",
                schema: "Academic",
                table: "TeacherFaculty",
                column: "FacultyId",
                principalSchema: "Academic",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherFaculty_Teacher_TeacherId",
                schema: "Academic",
                table: "TeacherFaculty",
                column: "TeacherId",
                principalSchema: "Academic",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherFaculty_Faculty_FacultyId",
                schema: "Academic",
                table: "TeacherFaculty");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherFaculty_Teacher_TeacherId",
                schema: "Academic",
                table: "TeacherFaculty");

            migrationBuilder.DropTable(
                name: "CommitteeEmployee",
                schema: "Administration.Committees");

            migrationBuilder.DropTable(
                name: "Committee",
                schema: "Administration.Committees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherFaculty",
                schema: "Academic",
                table: "TeacherFaculty");

            migrationBuilder.RenameTable(
                name: "TeacherFaculty",
                schema: "Academic",
                newName: "TeachersFaculty");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherFaculty_TeacherId",
                table: "TeachersFaculty",
                newName: "IX_TeachersFaculty_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherFaculty_FacultyId",
                table: "TeachersFaculty",
                newName: "IX_TeachersFaculty_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersFaculty",
                table: "TeachersFaculty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersFaculty_Faculty_FacultyId",
                table: "TeachersFaculty",
                column: "FacultyId",
                principalSchema: "Academic",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersFaculty_Teacher_TeacherId",
                table: "TeachersFaculty",
                column: "TeacherId",
                principalSchema: "Academic",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}