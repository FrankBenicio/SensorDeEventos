using Microsoft.EntityFrameworkCore;
using SensorDeEventos.Data.Mapeamento;
using SensorDeEventos.Domain.Models;
using System.Linq;

namespace SensorDeEventos.Data.Contexto
{
    public class SensorDeEventosContexto : DbContext
    {
        public SensorDeEventosContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(250)");
            }


            modelBuilder.ApplyConfiguration(new EventoMap());
        }
    }
}
