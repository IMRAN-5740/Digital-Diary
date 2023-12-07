using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommitteeEmployeeTableAdministrationSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNum",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");

            migrationBuilder.DropColumn(
                name: "PhoneNum",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");
        }
    }
}
