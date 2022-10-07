using EFCore_LibreriaDB;
using EFCore_LibreriaDB.Migrations;
using InventarioModelos;
using InventarioUtils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Actividad0302
{
    public class Program
    {
        private static IConfigurationRoot _configuracion;
        private static DbContextOptionsBuilder<InventarioDbContext> _opcionesBuilder;
        private const string _usuarioSistemaId = "5eeea222-8538-4009-b1ca-05662d52e64d";
        private const string _usuarioIngresadoId = "c089d3eb-f95a-45cb-8282-10215563352e";


        static void Main(string[] args)
        {
            Inicializacion();
            ListarInventario();
            ListadoArticulos();
            ListarArticulosCadenaDelimBarra();
            ArticulosValoresTotales();
            ArticulosDetalles();
        }

        static void Inicializacion()
        {
            _configuracion = ConfiguracionBuilderSingleton.ConfiguracionRoot;
            _opcionesBuilder = new DbContextOptionsBuilder<InventarioDbContext>();
            _opcionesBuilder.UseSqlServer(_configuracion.GetConnectionString("GestionInventarios"));
        }

        private static void ListarInventario()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var articulos = db.Articulos.OrderBy(a => a.Nombre).ToList();
                Console.WriteLine("=== Articulos ===");
                articulos.ForEach(a => Console.WriteLine($"Nombre: {a.Nombre}"));
            }
        }

        private static void ListadoArticulos()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var listado = db.ListadoArticulos.FromSqlRaw("EXECUTE dbo.ListadoArticulos").ToList();
                Console.WriteLine("=== Listado Articulos ===");
                foreach (var dato in listado)
                {
                    var salida = $"ARTICULO {dato.Nombre} {dato.Descripcion}";
                    if (!string.IsNullOrWhiteSpace(dato.CategoriaNombre))
                    {
                        salida = $"{salida}, Categoria: {dato.CategoriaNombre}";
                    }
                    Console.WriteLine(salida);
                }
            }
        }

        private static void ListarArticulosCadenaDelimBarra()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var EstaActivoParam = new SqlParameter("EstaActivo", 1);
                var resultado = db.ListadoArticulosCadena.FromSqlRaw("SELECT dbo.ArticulosNombresCadenaDelimBarra(@EstaActivo) ArticulosCadena", EstaActivoParam).FirstOrDefault();
                Console.WriteLine("=== Articulos Cadena Delimitada ===");
                Console.WriteLine($"Articulos Activos: {resultado.ArticulosCadena}");
            }
        }

        private static void ArticulosValoresTotales()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var EstaActivoParam = new SqlParameter("EstaActivo", 1);
                var listado = db.ArticuloValorTotales.FromSqlRaw("SELECT * FROM dbo.ArticulosValorTotal(@EstaActivo)", EstaActivoParam).ToList();
                Console.WriteLine("=== Articulos Valores Totales ===");
                foreach (var dato in listado)
                {
                    Console.WriteLine($"Articulo] {dato.Id, -10} |{dato.Nombre, -50} |{dato.Cantidad, -4} |{dato.ValorTotal, -5}");
                }
            }
        }

        public static void ArticulosDetalles()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var listado = db.ArticulosDetalles.FromSqlRaw("SELECT * FROM dbo.vwArticulosDetalles ORDER BY ArticuloNombre, GeneroNombre, CategoriaNombre, ParticipanteNombre").ToList();
                Console.WriteLine("=== Articulos Detalles ===");
                foreach (var dato in listado)
                {
                    Console.WriteLine($"Articulo] {dato.Id,-10} |{dato.ArticuloNombre,-50} |{dato.ArticuloDescripcion,-4} |{dato.ParticipanteNombre,-5} |{dato.CategoriaNombre, -5} |{dato.GeneroNombre, -5}");
                }
            }
        }
    }
}