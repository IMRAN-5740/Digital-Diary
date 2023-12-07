using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddOffice_and_OfficeEmployeeTableAdministrationSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CommonEntity");

            migrationBuilder.EnsureSchema(
                name: "Administration.Offices");

            migrationBuilder.RenameTable(
                name: "Designation",
                schema: "Academic",
                newName: "Designation",
                newSchema: "CommonEntity");

            migrationBuilder.CreateTable(
                name: "Office",
                schema: "Administration.Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeEmployee",
                schema: "Administration.Offices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeEmployee_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "Administration.Offices",
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEmployee_OfficeId",
                schema: "Administration.Offices",
                table: "OfficeEmployee",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeEmployee",
                schema: "Administration.Offices");

            migrationBuilder.DropTable(
                name: "Office",
                schema: "Administration.Offices");

            migrationBuilder.RenameTable(
                name: "Designation",
                schema: "CommonEntity",
                newName: "Designation",
                newSchema: "Academic");
        }
    }
}
