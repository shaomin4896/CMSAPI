﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_TestDate_For_BloodPressureTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TestDate",
                table: "BloodPressureTest",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDate",
                table: "BloodPressureTest");
        }
    }
}
