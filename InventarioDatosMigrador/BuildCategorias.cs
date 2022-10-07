using EFCore_LibreriaDB;
using InventarioModelos;

namespace InventarioDatosMigrador
{
    public sealed class BuildCategorias
    {
        private readonly InventarioDbContext _db;
        private const string _usuarioAlimentadorId = "31412031-7859-429c-ab21-c2e3e8d98042";

        public BuildCategorias(InventarioDbContext db)
        {
            _db = db;
        }

        public void EjecutarAlimentacion()
        {
            if (_db.Categorias.Count() == 0)
            {
                DateTime fechaCreacion = DateTime.Now;
                _db.Categorias.AddRange(
                        new Categoria() 
                        { 
                            FechaCreacion = fechaCreacion, 
                            EstaActivo = true, 
                            EstaEliminado = false, 
                            Nombre = "Peliculas", 
                            CategoriaDetalle = new CategoriaDetalle()
                            {
                                ColorValor = "#0000FF",
                                ColorNombre = "Azul"
                            }
                        },
                        new Categoria()
                        {
                            FechaCreacion = fechaCreacion,
                            EstaActivo = true,
                            EstaEliminado = false,
                            Nombre = "Libros",
                            CategoriaDetalle = new CategoriaDetalle()
                            {
                                ColorValor = "#FF0000",
                                ColorNombre = "Rojo"
                            }
                        },
                        new Categoria()
                        {
                            FechaCreacion = fechaCreacion,
                            EstaActivo = true,
                            EstaEliminado = false,
                            Nombre = "Juegos",
                            CategoriaDetalle = new CategoriaDetalle()
                            {
                                ColorValor = "#008000",
                                ColorNombre = "Verde"
                            }
                        }
                );
                _db.SaveChanges();
            }
        }
    }
}
