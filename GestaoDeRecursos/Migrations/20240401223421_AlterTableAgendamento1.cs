using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAgendamento1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraServico",
                table: "Agendamento");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Compareceu",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdDiaSemana",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdDiaSemana",
                table: "Agendamento",
                column: "IdDiaSemana");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_DiaSemana_IdDiaSemana",
                table: "Agendamento",
                column: "IdDiaSemana",
                principalTable: "DiaSemana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_DiaSemana_IdDiaSemana",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdDiaSemana",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Compareceu",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "IdDiaSemana",
                table: "Agendamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraServico",
                table: "Agendamento",
                type: "datetime2",
                nullable: true);
        }
    }
}
