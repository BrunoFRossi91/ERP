using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDeRecursos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adiciona a empresa "GDR"
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[Empresa] ([Nome], [DataInicioVigencia], [DataFimVigencia])
                VALUES ('GDR', GETDATE(), '2099-12-31')
            ");

            // Recupera o Id da empresa recém-criada
            migrationBuilder.Sql(@"
                DECLARE @EmpresaId INT
                SELECT @EmpresaId = Id FROM [dbo].[Empresa] WHERE [Nome] = 'GDR'
                
                -- Adiciona o usuário vinculado à empresa
                INSERT INTO [dbo].[Usuarios] ([Senha], [IdEmpresa], [DataCriacao], [DataModificacao], [Email], [PerguntaSecreta], [RespostaSecreta])
                VALUES ('Admin', @EmpresaId, GETDATE(), GETDATE(), 'brunofrossi@hotmail.com', 'Qual meu nome', 'Bruno')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove o usuário criado
            migrationBuilder.Sql(@"
                DELETE FROM [dbo].[Usuarios]
                WHERE [Email] = 'brunofrossi@hotmail.com'
            ");

            // Remove a empresa criada
            migrationBuilder.Sql(@"
                DELETE FROM [dbo].[Empresa]
                WHERE [Nome] = 'GDR'
            ");
        }
    }
}
