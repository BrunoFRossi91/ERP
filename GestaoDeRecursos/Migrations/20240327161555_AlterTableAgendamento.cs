using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    IdPacote = table.Column<int>(type: "int", nullable: false),
                    DataServico = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraServico = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioCriacao = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioModificacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Agendamento_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pacote_IdPacote",
                        column: x => x.IdPacote,
                        principalTable: "Pacote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Agendamento_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdCliente",
                table: "Agendamento",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdEmpresa",
                table: "Agendamento",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdPacote",
                table: "Agendamento",
                column: "IdPacote");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdServico",
                table: "Agendamento",
                column: "IdServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdPacote = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataServico = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraServico = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioCriacao = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioModificacao = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Pacote_IdPacote",
                        column: x => x.IdPacote,
                        principalTable: "Pacote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdCliente",
                table: "Agenda",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdEmpresa",
                table: "Agenda",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdPacote",
                table: "Agenda",
                column: "IdPacote");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdServico",
                table: "Agenda",
                column: "IdServico");
        }
    }
}
