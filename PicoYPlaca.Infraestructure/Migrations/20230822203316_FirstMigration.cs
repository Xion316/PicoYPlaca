using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PicoYPlaca.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CirculationResults",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanCirculate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CirculationResults");
        }
    }
}
