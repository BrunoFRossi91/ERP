using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoPacotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Pacote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Pacote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdServico",
                table: "Pacote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsuariosClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosClientes_Empresa_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosClientes_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_IdCliente",
                table: "Pacote",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_IdEmpresa",
                table: "Pacote",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_IdServico",
                table: "Pacote",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClientes_IdCliente",
                table: "UsuariosClientes",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosClientes_IdEmpresa",
                table: "UsuariosClientes",
                column: "IdEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacote_Clientes_IdCliente",
                table: "Pacote",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacote_Empresa_IdEmpresa",
                table: "Pacote",
                column: "IdEmpresa",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacote_Servicos_IdServico",
                table: "Pacote",
                column: "IdServico",
                principalTable: "Servicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacote_Clientes_IdCliente",
                table: "Pacote");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacote_Empresa_IdEmpresa",
                table: "Pacote");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacote_Servicos_IdServico",
                table: "Pacote");

            migrationBuilder.DropTable(
                name: "UsuariosClientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacote_IdCliente",
                table: "Pacote");

            migrationBuilder.DropIndex(
                name: "IX_Pacote_IdEmpresa",
                table: "Pacote");

            migrationBuilder.DropIndex(
                name: "IX_Pacote_IdServico",
                table: "Pacote");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Pacote");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Pacote");

            migrationBuilder.DropColumn(
                name: "IdServico",
                table: "Pacote");
        }
    }
}
