using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAgendamento3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "Agendamento");

            migrationBuilder.AddColumn<int>(
                name: "StatusAgendamento",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusAgendamento",
                table: "Agendamento");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
