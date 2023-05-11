using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class newIdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Case");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Case",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
