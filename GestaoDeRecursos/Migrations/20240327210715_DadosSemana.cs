using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class DadosSemana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Semana",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Domingo" },
                    { 2, "Segunda-feira" },
                    { 3, "Terça-feira" },
                    { 4, "Quarta-feira" },
                    { 5, "Quinta-feira" },
                    { 6, "Sexta-feira" },
                    { 7, "Sábado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
