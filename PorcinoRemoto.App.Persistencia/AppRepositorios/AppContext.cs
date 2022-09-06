using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PorcinoRemoto.App.Dominio;

namespace PorcinoRemoto.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Porcino> Porcinos { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PorcinoRemoto.Data");
            }
        }
    }
}