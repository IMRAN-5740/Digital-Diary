using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class Add_AcademicSectionDeanTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                schema: "Academic",
                table: "Dean",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Dean_DesignationId",
                schema: "Academic",
                table: "Dean",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dean_Designation_DesignationId",
                schema: "Academic",
                table: "Dean",
                column: "DesignationId",
                principalSchema: "CommonEntity",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dean_Designation_DesignationId",
                schema: "Academic",
                table: "Dean");

            migrationBuilder.DropIndex(
                name: "IX_Dean_DesignationId",
                schema: "Academic",
                table: "Dean");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "Academic",
                table: "Dean");
        }
    }
}