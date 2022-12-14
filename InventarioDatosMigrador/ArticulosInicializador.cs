
using EFCore_LibreriaDB;
using InventarioModelos;
using System;

namespace InventarioDatosMigrador
{
    public sealed class ArticulosInicializador
    {
        private readonly InventarioDbContext _db;
        private const string _usuarioInicializadorId = "31412031-7859-429c-ab21-c2e3e8d98042";

        public ArticulosInicializador(InventarioDbContext db)
        {
            _db = db;
        }

        public void Ejecutar()
        {
            if (_db.Articulos.Count() == 0)
            {
                var fechaCreacion = DateTime.Now;
                _db.Articulos.AddRange(
                    new Articulo()
                    {
                        Nombre = "Batman Inicia",
                        Descripcion = "Tu matas al heroe o vives lo suficiente para convertirte en villano",
                        Cantidad = 1_000,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 23.99M,
                        PrecioFinalOActual = 9.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Christian Bale",
                                Descripcion = "http://www.imdb.com/name/nm0000288/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Incepcion",
                        Descripcion = "No deberas tener miedo de soñar un poco mas",
                        Cantidad = 1_000,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 4.99M,
                        PrecioFinalOActual = 7.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Lonardo DiCaprio",
                                Descripcion = "http://www.imdb.com/name/nm0000138/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Recuerda Los Titanes",
                        Descripcion = "Lado izquierdo, lado fuerte",
                        Cantidad = 1_000,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 7.99M,
                        PrecioFinalOActual = 3.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Denzel Washington",
                                Descripcion = "http://www.imdb.com/name/nm0000243/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Star Wars El Imperio Contrataca",
                        Descripcion = "El se nos unira o morira, Maestro",
                        Cantidad = 1_000,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 35.99M,
                        PrecioFinalOActual = 19.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Mark Hamill",
                                Descripcion = "http://www.imdb.com/name/nm0000434/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Top Gun",
                        Descripcion = "Siento la necesidad de velocidad",
                        Cantidad = 1_000,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 8.99M,
                        PrecioFinalOActual = 6.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Tom Cruise",
                                Descripcion = "http://www.imdb.com/name/nm0000129/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Practical Entity Framework",
                        Descripcion = "El libro que estas leyendo de Entity Framework",
                        Cantidad = 1,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 28.99M,
                        PrecioFinalOActual = 27.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Brian L. Gorman",
                                Descripcion = "http://www.linkedin/in/brianlgorman/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "La Espada del Shannara",
                        Descripcion = "El libro de fantasia definitivo",
                        Cantidad = 900,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 13.99M,
                        PrecioFinalOActual = 9.99M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Terry Brooks",
                                Descripcion = "http://www.amazon.com/Sword-Shannara-Terry-Brooks/dp/0345314255",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Mundo de Tanques",
                        Descripcion = "Disparos en primera persona usando tanques de la 2da Guerra Mundial",
                        Cantidad = 1,
                        Notas = "",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 0.0M,
                        PrecioFinalOActual = 0.0M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Wargaming",
                                Descripcion = "http://worldoftanks.com/",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    },
                    new Articulo()
                    {
                        Nombre = "Battlefield 2142",
                        Descripcion = "Siento la necesidad de velocidad",
                        Cantidad = 1,
                        Notas = "El juego ya no esta activo",
                        EstaEnVenta = false,
                        FechaCompra = null,
                        FechaVenta = null,
                        PrecioCompra = 50.0M,
                        PrecioFinalOActual = 0.0M,
                        CreadoPorUsuarioId = _usuarioInicializadorId,
                        FechaCreacion = fechaCreacion,
                        EstaActivo = true,
                        EstaEliminado = false,
                        Participantes = new List<Participante>
                        {
                            new Participante()
                            {
                                Nombre = "Electronic Arts",
                                Descripcion = "http://en.wikipedia.org/wiki/Battlefield_2142",
                                CreadoPorUsuarioId = _usuarioInicializadorId,
                                FechaCreacion = fechaCreacion,
                                EstaActivo = true,
                                EstaEliminado = false,
                            }
                        }
                    }

                );
                _db.SaveChanges();
            }
        }
    }
}
