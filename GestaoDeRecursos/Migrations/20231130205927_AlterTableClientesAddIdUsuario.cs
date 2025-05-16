using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableClientesAddIdUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioCriacao",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioModificacao",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuarioCriacao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdUsuarioModificacao",
                table: "Clientes");
        }
    }
}
