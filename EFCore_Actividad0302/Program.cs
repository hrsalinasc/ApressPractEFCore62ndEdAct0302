using EFCore_LibreriaDB;
using EFCore_LibreriaDB.Migrations;
using InventarioModelos;
using InventarioUtils;
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
            //EliminarArticulos();
            AsegurarArticulos();
            ActualizarArticulos();
            ListarInventario();
            ListadoArticulos();
        }

        static void Inicializacion()
        {
            _configuracion = ConfiguracionBuilderSingleton.ConfiguracionRoot;
            _opcionesBuilder = new DbContextOptionsBuilder<InventarioDbContext>();
            _opcionesBuilder.UseSqlServer(_configuracion.GetConnectionString("GestionInventarios"));
        }

        static void AsegurarArticulos()
        {
            AsegurarArticulos("Batman Inicia", "Tu matas al heroe o vives lo suficiente para convertirte en villano", "Christian Bale, Katie Holmes");
            AsegurarArticulos("Incepcion", "No deberas tener miedo de soñar un poco mas", "Leonardo Dicaprio, Tom Hardy, Joseph Gordon-Levitt");
            AsegurarArticulos("Recuerda Los Titanes", "Lado izquierdo, lado fuerte", "Denzel Washington, Will Patton");
            AsegurarArticulos("Star Wars El Imperio Contrataca", "El se nos unira o morira, Maestro", "Harrison Ford, Carrie Fisher, Mark Hamill");
            AsegurarArticulos("Top Gun", "Siento la necesidad de velocidad", "Tom Cruise, Anthony Edwards, Val Killmer");
        }

        private static void AsegurarArticulos(string nombre, string descripcion, string notas)
        {
            Random random = new Random();
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                // verificar si el articulo existe
                var articulo = db.Articulos.FirstOrDefault(a => a.Nombre.ToLower() == nombre.ToLower());
                if (articulo == null)
                {
                    // articulo no existe, agregarlo
                    articulo = new Articulo()
                    {
                        Nombre = nombre,
                        CreadoPorUsuarioId = _usuarioIngresadoId,
                        EstaActivo = true,
                        Cantidad = random.Next(1, 1_000),
                        Descripcion = descripcion,
                        Notas = notas
                    };
                    db.Articulos.Add(articulo);
                    db.SaveChanges();
                }

            }
        }

        private static void ListarInventario()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var articulos = db.Articulos.OrderBy(a => a.Nombre).ToList();
                articulos.ForEach(a => Console.WriteLine($"Nombre: {a.Nombre}"));
            }
        }

        private static void EliminarArticulos()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var articulos = db.Articulos.ToList();
                db.Articulos.RemoveRange(articulos);
                db.SaveChanges();
            }
        }

        private static void ActualizarArticulos()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var articulos = db.Articulos.ToList();
                foreach (var articulo in articulos)
                {
                    articulo.PrecioFinalOActual = 9.99M;
                }
                db.Articulos.UpdateRange(articulos);
                db.SaveChanges();
            }
        }

        private static void ListadoArticulos()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var listado = db.ListadoArticulos.FromSqlRaw("EXECUTE dbo.ListadoArticulos").ToList();
                foreach(var dato in listado)
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
    }
}