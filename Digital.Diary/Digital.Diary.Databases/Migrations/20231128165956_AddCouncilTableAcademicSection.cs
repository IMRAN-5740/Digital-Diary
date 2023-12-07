using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddCouncilTableAcademicSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Council",
                schema: "Academic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Council", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Council_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "Academic",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Council_DesignationId",
                schema: "Academic",
                table: "Council",
                column: "DesignationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Council",
                schema: "Academic");
        }
    }
}
