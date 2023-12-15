using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class EmergencyServiceTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                schema: "EmergencyServices",
                table: "PostOffice");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "EmergencyServices",
                table: "PostOffice",
                newName: "PostOfficeName");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "PoliceStation",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "Journalist",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "GuestHouse",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "FireStation",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "District",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "Courier",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "Bus",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "AnsarForce",
                newName: "PhoneNum");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "EmergencyServices",
                table: "Ambulance",
                newName: "PhoneNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostOfficeName",
                schema: "EmergencyServices",
                table: "PostOffice",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "PoliceStation",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "Journalist",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "GuestHouse",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "FireStation",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "District",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "Courier",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "Bus",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "AnsarForce",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNum",
                schema: "EmergencyServices",
                table: "Ambulance",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                schema: "EmergencyServices",
                table: "PostOffice",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}