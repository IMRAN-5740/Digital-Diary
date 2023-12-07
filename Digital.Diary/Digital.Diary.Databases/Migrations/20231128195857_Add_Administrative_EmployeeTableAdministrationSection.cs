using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class Add_Administrative_EmployeeTableAdministrationSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                schema: "Administration.Offices",
                table: "OfficeEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEmployee_DesignationId",
                schema: "Administration.Offices",
                table: "OfficeEmployee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeEmployee_DesignationId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationEmployee_DesignationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationEmployee_Designation_DesignationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee",
                column: "DesignationId",
                principalSchema: "CommonEntity",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeEmployee_Designation_DesignationId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee",
                column: "DesignationId",
                principalSchema: "CommonEntity",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeEmployee_Designation_DesignationId",
                schema: "Administration.Offices",
                table: "OfficeEmployee",
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
                name: "FK_AssociationEmployee_Designation_DesignationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_CommitteeEmployee_Designation_DesignationId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeEmployee_Designation_DesignationId",
                schema: "Administration.Offices",
                table: "OfficeEmployee");

            migrationBuilder.DropIndex(
                name: "IX_OfficeEmployee_DesignationId",
                schema: "Administration.Offices",
                table: "OfficeEmployee");

            migrationBuilder.DropIndex(
                name: "IX_CommitteeEmployee_DesignationId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");

            migrationBuilder.DropIndex(
                name: "IX_AssociationEmployee_DesignationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "Administration.Offices",
                table: "OfficeEmployee");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "Administration.Committees",
                table: "CommitteeEmployee");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "Administration.Associations",
                table: "AssociationEmployee");
        }
    }
}
