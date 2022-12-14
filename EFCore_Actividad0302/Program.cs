using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCore_LibreriaDB;
using EFCore_LibreriaDB.Migrations;
using InventarioModelos;
using InventarioModelos.ModelosDato;
using InventarioUtils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore_Actividad0302
{
    public class Program
    {
        private static IConfigurationRoot _configuracion;
        private static DbContextOptionsBuilder<InventarioDbContext> _opcionesBuilder;
        private const string _usuarioSistemaId = "5eeea222-8538-4009-b1ca-05662d52e64d";
        private const string _usuarioIngresadoId = "c089d3eb-f95a-45cb-8282-10215563352e";

        private static MapperConfiguration _mapperConfig;
        private static IMapper _mapper;
        private static IServiceProvider _serviceProvider;


        static void Main(string[] args)
        {
            Inicializacion();
            InicializaMapper();
            
            ListarInventario();
            ListarInventarioConProyeccion();
            ListarCategoriasYColores();
            //ListadoArticulos();
            //ListadoArticulosConLinq();
            //ListarArticulosCadenaDelimBarra();
            //ArticulosValoresTotales();
            //ArticulosDetalles();
        }

        static void Inicializacion()
        {
            _configuracion = ConfiguracionBuilderSingleton.ConfiguracionRoot;
            _opcionesBuilder = new DbContextOptionsBuilder<InventarioDbContext>();
            _opcionesBuilder.UseSqlServer(_configuracion.GetConnectionString("GestionInventarios"));

            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InventarioMapper>();
            });
            _mapperConfig.AssertConfigurationIsValid();
            _mapper = _mapperConfig.CreateMapper();
        }

        static void InicializaMapper()
        {
            var servicios = new ServiceCollection();
            servicios.AddAutoMapper(typeof(InventarioMapper));
            _serviceProvider = servicios.BuildServiceProvider();
        }

        private static void ListarInventario()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var articulos = db.Articulos.OrderBy(a => a.Nombre).ToList();
                var listado = _mapper.Map<List<Articulo>, List<ArticuloDatos>>(articulos);
                Console.WriteLine("=== Listar Inventarios ===");
                listado.ForEach(a => Console.WriteLine($"Nombre: {a.Nombre}"));
            }
        }

        private static void ListarInventarioConProyeccion()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var articulos = db.Articulos
                                    .OrderBy(a => a.Nombre)
                                    .ProjectTo<ArticuloDatos>(_mapper.ConfigurationProvider)
                                    .ToList();
                Console.WriteLine("=== Listar Inventarios con Proyeccion ===");
                articulos.ForEach(a => Console.WriteLine($"Articulo: {a}"));
            }
        }

        private static void ListarCategoriasYColores()
        {
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var resultado = db.Categorias
                                    .Include(x => x.CategoriaDetalle)
                                    .ProjectTo<CategoriaDatos>(_mapper.ConfigurationProvider)
                                    .ToList();
                Console.WriteLine("=== Listar Inventarios Categorias Y Colores ===");
                foreach(var c in resultado)
                {
                    Console.WriteLine($"Categoria [{c.Categoria}] es {c.CategoriaDetalle.Color}");
                }
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

        public static void ListadoArticulosConLinq()
        {
            var fechaMin = new DateTime(2021, 1, 1);
            var fechaMax = new DateTime(2024, 1, 1);
            using (var db = new InventarioDbContext(_opcionesBuilder.Options))
            {
                var listado = db.Articulos.Select(x => new ArticuloDatos
                {
                    FechaCreacion = x.FechaCreacion,
                    CategoriaNombre = x.Categoria.Nombre,
                    Descripcion = x.Descripcion,
                    EstaActivo = x.EstaActivo,
                    EstaEliminado = x.EstaEliminado,
                    Nombre = x.Nombre,
                    Notas = x.Notas,
                    CategoriaId = x.Categoria.Id,
                    Id = x.Id
                })
                .Where(x => x.FechaCreacion >= fechaMin && x.FechaCreacion <= fechaMax)
                .OrderBy(y => y.CategoriaNombre)
                .ThenBy(z => z.Nombre)
                .ToList();

                Console.WriteLine("=== Articulos Detalles con LinQ===");
                foreach (var articuloDato in listado)
                {
                    Console.WriteLine(articuloDato);
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