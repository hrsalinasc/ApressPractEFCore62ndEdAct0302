using EFCore_LibreriaDB;
using InventarioUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InventarioDatosMigrador
{
    internal class Program
    {
        private static IConfigurationRoot _configuracion;
        private static DbContextOptionsBuilder<InventarioDbContext> _opcionesBuilder;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Inicializacion();
            AplicarMigraciones();
            EjecutarAlimentacionDatos();
        }

        static void Inicializacion()
        {
            _configuracion = ConfiguracionBuilderSingleton.ConfiguracionRoot;
            _opcionesBuilder = new DbContextOptionsBuilder<InventarioDbContext>();
            _opcionesBuilder.UseSqlServer(_configuracion.GetConnectionString("GestionInventarios"));
        }

        public static void AplicarMigraciones()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                db.Database.Migrate();
            }
        }

        public static void EjecutarAlimentacionDatos()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var categorias = new BuildCategorias(db);
                categorias.EjecutarAlimentacion();
                var articulosIni = new ArticulosInicializador(db);
                articulosIni.Ejecutar();
            }
        }
    }
}