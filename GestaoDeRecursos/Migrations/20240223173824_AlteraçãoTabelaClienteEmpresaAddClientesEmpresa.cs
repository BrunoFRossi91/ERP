using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãoTabelaClienteEmpresaAddClientesEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresa_IdEmpresa",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdEmpresa",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PerguntaSecreta",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RespostaSecreta",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PerguntaSecreta",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RespostaSecreta",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PerguntaSecreta",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RespostaSecreta",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PerguntaSecreta",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RespostaSecreta",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEmpresa",
                table: "Clientes",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresa_IdEmpresa",
                table: "Clientes",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
