using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicoYPlaca.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CirculationResultIdChangev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_CirculationResults",
                table: "CirculationResults",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CirculationResults",
                table: "CirculationResults");
        }
    }
}
