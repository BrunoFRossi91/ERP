using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class alterandoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosClientes_Empresa_IdCliente",
                table: "UsuariosClientes");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosClientes_Clientes_IdCliente",
                table: "UsuariosClientes",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosClientes_Clientes_IdCliente",
                table: "UsuariosClientes");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosClientes_Empresa_IdCliente",
                table: "UsuariosClientes",
                column: "IdCliente",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
