using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWithMe.Travel.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Travels",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TravelDetails",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValueSql: "NULL",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Travels",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "TravelDetails",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldDefaultValueSql: "NULL");
        }
    }
}
