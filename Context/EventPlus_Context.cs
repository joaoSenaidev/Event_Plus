using Event_Plus.Domains;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Context
{
    public class EventPlus_Context : DbContext
    {
        public EventPlus_Context()
        {
        }

        public EventPlus_Context(DbContextOptions<EventPlus_Context> options) : base(options)
        {
        }

        /// <summary>
        /// Define que as classes se transformarão em tabelas no BD
        /// </summary>
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TipoUsuarios> TipoUsuario { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<TipoEventos> TipoEventos { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<Instituicoes> Instituicoes { get; set; }
        public DbSet<ComentarioEventos> ComentarioEventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE28-S28\\SQLEXPRESS; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");

            }

        }
    }
}
