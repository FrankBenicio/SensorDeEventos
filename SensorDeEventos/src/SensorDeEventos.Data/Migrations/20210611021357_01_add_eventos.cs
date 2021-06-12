using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorDeEventos.Data.Migrations
{
    public partial class _01_add_eventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<long>(type: "bigint", nullable: false),
                    Tag = table.Column<string>(type: "varchar(50)", nullable: false),
                    Valor = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
