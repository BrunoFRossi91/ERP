using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableDiaSemana1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraInicioExpediente",
                table: "DiaSemana",
                newName: "HoraInicioAtendimento");

            migrationBuilder.RenameColumn(
                name: "HoraFimExpediente",
                table: "DiaSemana",
                newName: "HoraFimAtendimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoraInicioAtendimento",
                table: "DiaSemana",
                newName: "HoraInicioExpediente");

            migrationBuilder.RenameColumn(
                name: "HoraFimAtendimento",
                table: "DiaSemana",
                newName: "HoraFimExpediente");
        }
    }
}
