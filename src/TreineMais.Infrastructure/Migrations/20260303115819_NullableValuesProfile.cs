using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreineMais.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullableValuesProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight_Value",
                table: "Profiles",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Height_Value",
                table: "Profiles",
                newName: "Height");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Profiles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Profiles",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Profiles",
                type: "numeric(5,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Profiles",
                type: "numeric(4,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "numeric(4,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Profiles",
                newName: "Weight_Value");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Profiles",
                newName: "Height_Value");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Profiles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Profiles",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Weight_Value",
                table: "Profiles",
                type: "numeric(5,2)",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "numeric(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Height_Value",
                table: "Profiles",
                type: "numeric(4,2)",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "numeric(4,2)",
                oldNullable: true);
        }
    }
}
