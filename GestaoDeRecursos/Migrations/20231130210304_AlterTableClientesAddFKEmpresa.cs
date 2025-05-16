using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableClientesAddFKEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
