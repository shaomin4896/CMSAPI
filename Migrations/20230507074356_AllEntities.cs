using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CmsUser",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<int>(type: "int", nullable: false),
                    IsMale = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CustomerId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DoctorName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeekDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndReason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Height = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Waistline = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AllergyMd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalHistory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FamilyMedicalHistory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contactor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MangerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_CmsUser_MangerId",
                        column: x => x.MangerId,
                        principalTable: "CmsUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Case_CmsUser_PatientId",
                        column: x => x.PatientId,
                        principalTable: "CmsUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BloodTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HBAIC = table.Column<double>(type: "double", nullable: false),
                    BloodSugarBeforeMeal = table.Column<double>(type: "double", nullable: false),
                    BloodSugarAfterMeal = table.Column<double>(type: "double", nullable: false),
                    TG = table.Column<double>(type: "double", nullable: false),
                    Creatinine = table.Column<double>(type: "double", nullable: false),
                    CmsCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodTest_Case_CmsCaseId",
                        column: x => x.CmsCaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EyeTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsNormal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CmsCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EyeTest_Case_CmsCaseId",
                        column: x => x.CmsCaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FootTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsLeftNormal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsRightNormal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CmsCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootTest_Case_CmsCaseId",
                        column: x => x.CmsCaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UrineTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DidRoutine = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LDL = table.Column<double>(type: "double", nullable: false),
                    Microprotein = table.Column<double>(type: "double", nullable: false),
                    CmsCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrineTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrineTest_Case_CmsCaseId",
                        column: x => x.CmsCaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTest_CmsCaseId",
                table: "BloodTest",
                column: "CmsCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_MangerId",
                table: "Case",
                column: "MangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_PatientId",
                table: "Case",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EyeTest_CmsCaseId",
                table: "EyeTest",
                column: "CmsCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_FootTest_CmsCaseId",
                table: "FootTest",
                column: "CmsCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UrineTest_CmsCaseId",
                table: "UrineTest",
                column: "CmsCaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTest");

            migrationBuilder.DropTable(
                name: "EyeTest");

            migrationBuilder.DropTable(
                name: "FootTest");

            migrationBuilder.DropTable(
                name: "UrineTest");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CmsUser");
        }
    }
}
