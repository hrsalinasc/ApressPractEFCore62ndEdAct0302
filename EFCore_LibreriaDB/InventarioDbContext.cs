using InventarioModelos;
using InventarioModelos.ModelosDato;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_LibreriaDB
{
    public class InventarioDbContext : DbContext
    {
        private static IConfigurationRoot _configuracion;
        private const string _usuarioSistemaId = "5eeea222-8538-4009-b1ca-05662d52e64d";


        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaDetalle> CategoriaDetalles { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public DbSet<ListadoArticuloDatos> ListadoArticulos { get; set; }
        public DbSet<ListadoArticulosNombresDelimBarraDatos> ListadoArticulosCadena { get; set; }
        public DbSet<ArticuloValorTotalDatos> ArticuloValorTotales { get; set; }


        public InventarioDbContext()
        {

        }

        public InventarioDbContext(DbContextOptions opciones)
            : base(opciones)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder opcionesBuilder)
        {
            if (!opcionesBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuracion = builder.Build();
                var cadenaConexion = _configuracion.GetConnectionString("GestionInventarios");
                opcionesBuilder.UseSqlServer(cadenaConexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>()
                                .HasMany(a => a.Participantes)
                                .WithMany(p => p.Articulos)
                                .UsingEntity<Dictionary<string, object>>(
                                    "ArticulosParticipantes",
                                    ap => ap.HasOne<Participante>()
                                            .WithMany()
                                            .HasForeignKey("ParticipanteId")
                                            .HasConstraintName("FK_ArticuloParticipante_Participantes_ParticipanteId")
                                            .OnDelete(DeleteBehavior.Cascade),
                                    ap => ap.HasOne<Articulo>()
                                            .WithMany()
                                            .HasForeignKey("ArticuloId")
                                            .HasConstraintName("FK_ParticipanteArticulo_Articulos_ArticuloId")
                                            .OnDelete(DeleteBehavior.ClientCascade)
                                );
            modelBuilder.Entity<ListadoArticuloDatos>(x =>
            {
                x.HasNoKey();
                x.ToView("ListadoArticulos");   // <<--- public DbSet<ListadoArticuloDatos> ListadoArticulos { get; set; }
            });

            modelBuilder.Entity<ListadoArticulosNombresDelimBarraDatos>(x =>
            {
                x.HasNoKey();
                x.ToView("ListadoArticulosCadena");
            });

            modelBuilder.Entity<ArticuloValorTotalDatos>(x => 
            {
                x.HasNoKey();
                x.ToView("ArticuloValorTotales");
            });

            var generoFechaCreacion = new DateTime(2022, 10, 03);
            modelBuilder.Entity<Genero>(x =>
            {
                x.HasData(
                        new Genero() { Id = 1, FechaCreacion = generoFechaCreacion, EstaActivo = true, EstaEliminado = false, Nombre = "Fantasia" },
                        new Genero() { Id = 2, FechaCreacion = generoFechaCreacion, EstaActivo = true, EstaEliminado = false, Nombre = "Siencia Ficcion" },
                        new Genero() { Id = 3, FechaCreacion = generoFechaCreacion, EstaActivo = true, EstaEliminado = false, Nombre = "Horro" },
                        new Genero() { Id = 4, FechaCreacion = generoFechaCreacion, EstaActivo = true, EstaEliminado = false, Nombre = "Comedia" },
                        new Genero() { Id = 5, FechaCreacion = generoFechaCreacion, EstaActivo = true, EstaEliminado = false, Nombre = "Drama" }
                    );
            });
        }

        public override int SaveChanges()
        {
            var rastreador = ChangeTracker;

            foreach (var entrada in rastreador.Entries())
            {
                System.Diagnostics.Debug.WriteLine($"{entrada.Entity} tiene un estado {entrada.State}");
                if (entrada.Entity is AuditorModelo)
                {
                    var entidad = entrada.Entity as AuditorModelo;
                    switch (entrada.State)
                    {
                        case EntityState.Added:
                            entidad.FechaCreacion = DateTime.Now;
                            if (string.IsNullOrWhiteSpace(entidad.CreadoPorUsuarioId))
                            {
                                entidad.CreadoPorUsuarioId = _usuarioSistemaId;
                            }
                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            entidad.FechaModificacion = DateTime.Now;
                            if (string.IsNullOrWhiteSpace(entidad.ModificadoPorUsuarioId))
                            {
                                entidad.ModificadoPorUsuarioId = _usuarioSistemaId;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}