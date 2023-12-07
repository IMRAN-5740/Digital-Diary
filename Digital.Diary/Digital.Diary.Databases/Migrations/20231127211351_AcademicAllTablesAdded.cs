using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AcademicAllTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Academic");

            migrationBuilder.CreateTable(
                name: "Designation",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dean",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dean", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dean_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "Academic",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "Academic",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrTable",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrTable_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Academic",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Academic",
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "Academic",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "Academic",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeachersFaculty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersFaculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersFaculty_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "Academic",
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersFaculty_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Academic",
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrTable_DepartmentId",
                schema: "Academic",
                table: "CrTable",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dean_FacultyId",
                schema: "Academic",
                table: "Dean",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                schema: "Academic",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DepartmentId",
                schema: "Academic",
                table: "Teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_DesignationId",
                schema: "Academic",
                table: "Teacher",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_FacultyId",
                schema: "Academic",
                table: "Teacher",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersFaculty_FacultyId",
                table: "TeachersFaculty",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersFaculty_TeacherId",
                table: "TeachersFaculty",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrTable",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Dean",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "TeachersFaculty");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "Academic");

            migrationBuilder.DropTable(
                name: "Faculty",
                schema: "Academic");
        }
    }
}