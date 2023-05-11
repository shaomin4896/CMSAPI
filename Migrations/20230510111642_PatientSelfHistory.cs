using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class PatientSelfHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthHistory_CmsUser_ManagerId",
                table: "HealthHistory");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "HealthHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "Case",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BloodPressureTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Systolic = table.Column<double>(type: "double", nullable: false),
                    Diastolic = table.Column<double>(type: "double", nullable: false),
                    CmsCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressureTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodPressureTest_Case_CmsCaseId",
                        column: x => x.CmsCaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatientSelfHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Height = table.Column<double>(type: "double", nullable: false),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    MedicineRecord = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FootCare = table.Column<int>(type: "int", nullable: false),
                    SportCare = table.Column<int>(type: "int", nullable: false),
                    MouseCare = table.Column<int>(type: "int", nullable: false),
                    BloodPressureTestId = table.Column<int>(type: "int", nullable: false),
                    FootTestId = table.Column<int>(type: "int", nullable: false),
                    BloodTestId = table.Column<int>(type: "int", nullable: false),
                    CmsCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSelfHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSelfHistory_BloodPressureTest_BloodPressureTestId",
                        column: x => x.BloodPressureTestId,
                        principalTable: "BloodPressureTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSelfHistory_BloodTest_BloodTestId",
                        column: x => x.BloodTestId,
                        principalTable: "BloodTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSelfHistory_Case_CmsCaseId",
                        column: x => x.CmsCaseId,
                        principalTable: "Case",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientSelfHistory_FootTest_FootTestId",
                        column: x => x.FootTestId,
                        principalTable: "FootTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressureTest_CmsCaseId",
                table: "BloodPressureTest",
                column: "CmsCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSelfHistory_BloodPressureTestId",
                table: "PatientSelfHistory",
                column: "BloodPressureTestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSelfHistory_BloodTestId",
                table: "PatientSelfHistory",
                column: "BloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSelfHistory_CmsCaseId",
                table: "PatientSelfHistory",
                column: "CmsCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSelfHistory_FootTestId",
                table: "PatientSelfHistory",
                column: "FootTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthHistory_CmsUser_ManagerId",
                table: "HealthHistory",
                column: "ManagerId",
                principalTable: "CmsUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthHistory_CmsUser_ManagerId",
                table: "HealthHistory");

            migrationBuilder.DropTable(
                name: "PatientSelfHistory");

            migrationBuilder.DropTable(
                name: "BloodPressureTest");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "HealthHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientName",
                table: "Case",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthHistory_CmsUser_ManagerId",
                table: "HealthHistory",
                column: "ManagerId",
                principalTable: "CmsUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
