using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicoYPlaca.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CirculationResultIdChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CirculationResults",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CirculationResults");
        }
    }
}
