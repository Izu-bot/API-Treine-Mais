using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreineMais.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight_Value",
                table: "Profiles",
                type: "numeric(5,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "numeric(3,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Height_Value",
                table: "Profiles",
                type: "numeric(4,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "numeric(3,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight_Value",
                table: "Profiles",
                type: "numeric(3,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "numeric(5,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Height_Value",
                table: "Profiles",
                type: "numeric(3,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "numeric(4,2)");
        }
    }
}
