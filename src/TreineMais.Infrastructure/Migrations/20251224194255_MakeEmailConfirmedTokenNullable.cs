using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreineMais.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeEmailConfirmedTokenNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailConfirmedToken",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailConfirmedToken",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
