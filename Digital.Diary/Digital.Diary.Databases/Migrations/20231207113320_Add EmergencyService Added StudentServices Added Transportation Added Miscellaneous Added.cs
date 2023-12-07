using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Diary.Databases.Migrations
{
    /// <inheritdoc />
    public partial class AddEmergencyServiceAddedStudentServicesAddedTransportationAddedMiscellaneousAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EmergencyServices");

            migrationBuilder.EnsureSchema(
                name: "Miscellaneous");

            migrationBuilder.EnsureSchema(
                name: "StudentActivities.Clubs");

            migrationBuilder.EnsureSchema(
                name: "Administration.Transportation");

            migrationBuilder.CreateTable(
                name: "Ambulance",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbulanceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnsarForce",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnsarStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsarForce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "Miscellaneous",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                schema: "StudentActivities.Clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courier",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireStation",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FireStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireStation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestHouse",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journalist",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journalist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliceStation",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceStation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceStation_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "CommonEntity",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostOffice",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOffice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostOffice_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "CommonEntity",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                schema: "EmergencyServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                schema: "Administration.Transportation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankEmployee",
                schema: "Miscellaneous",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankEmployee_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Miscellaneous",
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankEmployee_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "CommonEntity",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubEmployee",
                schema: "StudentActivities.Clubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubEmployee_Club_ClubId",
                        column: x => x.ClubId,
                        principalSchema: "StudentActivities.Clubs",
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubEmployee_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "CommonEntity",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportEmployee",
                schema: "Administration.Transportation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportEmployee_Designation_DesignationId",
                        column: x => x.DesignationId,
                        principalSchema: "CommonEntity",
                        principalTable: "Designation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportEmployee_Transport_TransportId",
                        column: x => x.TransportId,
                        principalSchema: "Administration.Transportation",
                        principalTable: "Transport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankEmployee_BankId",
                schema: "Miscellaneous",
                table: "BankEmployee",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankEmployee_DesignationId",
                schema: "Miscellaneous",
                table: "BankEmployee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubEmployee_ClubId",
                schema: "StudentActivities.Clubs",
                table: "ClubEmployee",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubEmployee_DesignationId",
                schema: "StudentActivities.Clubs",
                table: "ClubEmployee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStation_DesignationId",
                schema: "EmergencyServices",
                table: "PoliceStation",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOffice_DesignationId",
                schema: "EmergencyServices",
                table: "PostOffice",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEmployee_DesignationId",
                schema: "Administration.Transportation",
                table: "TransportEmployee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEmployee_TransportId",
                schema: "Administration.Transportation",
                table: "TransportEmployee",
                column: "TransportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambulance",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "AnsarForce",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "BankEmployee",
                schema: "Miscellaneous");

            migrationBuilder.DropTable(
                name: "Bus",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "ClubEmployee",
                schema: "StudentActivities.Clubs");

            migrationBuilder.DropTable(
                name: "Courier",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "District",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "FireStation",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "GuestHouse",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "Journalist",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "PoliceStation",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "PostOffice",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "Train",
                schema: "EmergencyServices");

            migrationBuilder.DropTable(
                name: "TransportEmployee",
                schema: "Administration.Transportation");

            migrationBuilder.DropTable(
                name: "Bank",
                schema: "Miscellaneous");

            migrationBuilder.DropTable(
                name: "Club",
                schema: "StudentActivities.Clubs");

            migrationBuilder.DropTable(
                name: "Transport",
                schema: "Administration.Transportation");
        }
    }
}