using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    CoxaDireita = table.Column<double>(type: "float", nullable: false),
                    CoxaEsquerda = table.Column<double>(type: "float", nullable: false),
                    PanturrilhaDireita = table.Column<double>(type: "float", nullable: false),
                    PanturrilhaEsquerda = table.Column<double>(type: "float", nullable: false),
                    Gluteo = table.Column<double>(type: "float", nullable: false),
                    BracoDireito = table.Column<double>(type: "float", nullable: false),
                    BracoEsquerdo = table.Column<double>(type: "float", nullable: false),
                    Peito = table.Column<double>(type: "float", nullable: false),
                    AbdomenInfra = table.Column<double>(type: "float", nullable: false),
                    AbdomenSupra = table.Column<double>(type: "float", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacaos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacaos");
        }
    }
}
