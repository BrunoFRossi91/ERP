using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data
{
    public class GDRContext : DbContext
    {
        public GDRContext(DbContextOptions<GDRContext> opts)
            : base(opts) { }

        public DbSet<EntityCliente> Clientes { get; set; }
        public DbSet<EntityEmpresa> Empresa { get; set; }
        public DbSet<EntityUsuarios> Usuarios { get; set; }
        public DbSet<EntityServicos> Servicos { get; set; }
        public DbSet<EntityObrigacoes> Obrigacacoes { get; set; }
        public DbSet<EntityDiaSemana> DiaSemana { get; set; }
        public DbSet<EntityMetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<EntityAgendamento> Agendamento { get; set; }
        public DbSet<EntityPacote> Pacote { get; set; }
        public DbSet<EntityUsuariosCliente> UsuariosClientes { get; set; }
        public DbSet<EntitySemana> Semana { get; set; }

        public DbSet<EntityAvaliacao> Avaliacaos { get; set; }
    }
}
