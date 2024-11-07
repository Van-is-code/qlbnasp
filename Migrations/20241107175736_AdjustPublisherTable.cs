using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.Net_MvcWeb_Pj3.Aptech.Migrations
{
    /// <inheritdoc />
    public partial class AdjustPublisherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boold_Type",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ExportDate",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "GenDer",
                table: "Patient",
                newName: "Gender");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Patient",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Patient",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Blood_Type",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blood_Type",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Patient",
                newName: "GenDer");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Patient",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Patient",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Boold_Type",
                table: "Patient",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExportDate",
                table: "Patient",
                type: "datetime2",
                nullable: true);
        }
    }
}
