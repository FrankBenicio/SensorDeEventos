using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorDeEventos.Data.Migrations
{
    public partial class _03_update_eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Eventos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Eventos");
        }
    }
}
