using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Consignors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConsignorName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HandoverPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HandoverPointName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandoverPoint", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SelectabilityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SelectabilityStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectabilityStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SelectabilityStatusId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carriers_SelectabilityStatus_SelectabilityStatusId",
                        column: x => x.SelectabilityStatusId,
                        principalTable: "SelectabilityStatus",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CarrierBranchCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProviderId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarrierBranchName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    Parameters = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierBranchCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrierBranchCategories_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomerPickUpBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CarrierBranchId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarrierId = table.Column<int>(type: "int", nullable: true),
                    CarrierBranchCategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomerPickUpBranchName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerPickUpBranchName2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Photo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<Point>(type: "point", nullable: false),
                    CardPayment = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsExists = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPickUpBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPickUpBranches_CarrierBranchCategories_CarrierBranch~",
                        column: x => x.CarrierBranchCategoryId,
                        principalTable: "CarrierBranchCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPickUpBranches_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransportServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarrierId = table.Column<int>(type: "int", nullable: false),
                    ConsignorId = table.Column<int>(type: "int", nullable: false),
                    CustomerFacingName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HandoverPointSourceId = table.Column<int>(type: "int", nullable: true),
                    HandoverPointDestinationId = table.Column<int>(type: "int", nullable: true),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SelectabilityStatusId = table.Column<int>(type: "int", nullable: true),
                    CarrierBranchCategoryId = table.Column<int>(type: "int", nullable: true),
                    PreviousTransportsServiceId = table.Column<int>(type: "int", nullable: true),
                    PreviousTransportServiceId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportServices_CarrierBranchCategories_CarrierBranchCateg~",
                        column: x => x.CarrierBranchCategoryId,
                        principalTable: "CarrierBranchCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportServices_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportServices_Consignors_ConsignorId",
                        column: x => x.ConsignorId,
                        principalTable: "Consignors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportServices_HandoverPoint_HandoverPointDestinationId",
                        column: x => x.HandoverPointDestinationId,
                        principalTable: "HandoverPoint",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportServices_HandoverPoint_HandoverPointSourceId",
                        column: x => x.HandoverPointSourceId,
                        principalTable: "HandoverPoint",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportServices_SelectabilityStatus_SelectabilityStatusId",
                        column: x => x.SelectabilityStatusId,
                        principalTable: "SelectabilityStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportServices_TransportServices_PreviousTransportsServic~",
                        column: x => x.PreviousTransportsServiceId,
                        principalTable: "TransportServices",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(type: "int", nullable: false),
                    TimeFrom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeTo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerPickUpBranchModelId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHours_CustomerPickUpBranches_CustomerPickUpBranchModelId",
                        column: x => x.CustomerPickUpBranchModelId,
                        principalTable: "CustomerPickUpBranches",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "SelectabilityStatus",
                columns: new[] { "Id", "SelectabilityStatus" },
                values: new object[,]
                {
                    { 0, "HIDE" },
                    { 1, "DISABLED" },
                    { 2, "ENABLED" }
                });

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "Id", "IsDeleted", "Name", "SelectabilityStatusId" },
                values: new object[,]
                {
                    { 1, false, "VIVANTIS", 2 },
                    { 2, false, "Česká pošta", 2 },
                    { 3, false, "PPL", 2 },
                    { 4, false, "Uloženka", 2 },
                    { 5, false, "GLS", 2 },
                    { 6, false, "Pošta bez hranic", 2 },
                    { 7, false, "In Time", 2 },
                    { 8, false, "Cargus", 2 },
                    { 9, false, "DHL", 2 },
                    { 10, false, "Slovenská pošta", 2 },
                    { 11, false, "DPD PickUp", 2 },
                    { 12, false, "DPD", 2 },
                    { 13, false, "Zásilkovna", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrierBranchCategories_CarrierId",
                table: "CarrierBranchCategories",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_SelectabilityStatusId",
                table: "Carriers",
                column: "SelectabilityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPickUpBranches_CarrierBranchCategoryId",
                table: "CustomerPickUpBranches",
                column: "CarrierBranchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPickUpBranches_CarrierId",
                table: "CustomerPickUpBranches",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_CarrierBranchCategoryId",
                table: "TransportServices",
                column: "CarrierBranchCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_CarrierId",
                table: "TransportServices",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_ConsignorId",
                table: "TransportServices",
                column: "ConsignorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_HandoverPointDestinationId",
                table: "TransportServices",
                column: "HandoverPointDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_HandoverPointSourceId",
                table: "TransportServices",
                column: "HandoverPointSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_PreviousTransportsServiceId",
                table: "TransportServices",
                column: "PreviousTransportsServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportServices_SelectabilityStatusId",
                table: "TransportServices",
                column: "SelectabilityStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_CustomerPickUpBranchModelId",
                table: "WorkHours",
                column: "CustomerPickUpBranchModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportServices");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "Consignors");

            migrationBuilder.DropTable(
                name: "HandoverPoint");

            migrationBuilder.DropTable(
                name: "CustomerPickUpBranches");

            migrationBuilder.DropTable(
                name: "CarrierBranchCategories");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "SelectabilityStatus");
        }
    }
}
