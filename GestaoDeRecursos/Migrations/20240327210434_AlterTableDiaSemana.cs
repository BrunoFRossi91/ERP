using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableDiaSemana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "DiaSemana");

            migrationBuilder.AddColumn<int>(
                name: "IdSemana",
                table: "DiaSemana",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DiaSemana_IdSemana",
                table: "DiaSemana",
                column: "IdSemana");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaSemana_Semana_IdSemana",
                table: "DiaSemana",
                column: "IdSemana",
                principalTable: "Semana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaSemana_Semana_IdSemana",
                table: "DiaSemana");

            migrationBuilder.DropIndex(
                name: "IX_DiaSemana_IdSemana",
                table: "DiaSemana");

            migrationBuilder.DropColumn(
                name: "IdSemana",
                table: "DiaSemana");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "DiaSemana",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");
        }
    }
}
