using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddAssosiation_and_AssociationEmployeeTableAdministrationSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Administration.Associations");

            migrationBuilder.CreateTable(
                name: "Association",
                schema: "Administration.Associations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssociationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssociationEmployee",
                schema: "Administration.Associations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssociationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociationEmployee_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalSchema: "Administration.Associations",
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociationEmployee_AssociationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee",
                column: "AssociationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationEmployee",
                schema: "Administration.Associations");

            migrationBuilder.DropTable(
                name: "Association",
                schema: "Administration.Associations");
        }
    }
}
