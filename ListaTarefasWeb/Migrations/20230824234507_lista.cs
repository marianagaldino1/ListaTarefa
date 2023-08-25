using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaTarefasAPI.Migrations
{
    public partial class lista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id_Tarefa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTarefa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CustoTarefa = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    DataLimite = table.Column<DateTime>(type: "date", nullable: false),
                    Ordem = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id_Tarefa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
