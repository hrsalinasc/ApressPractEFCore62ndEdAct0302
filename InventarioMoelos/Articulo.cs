using System.ComponentModel.DataAnnotations;

namespace InventarioModelos
{
    public class Articulo : AuditorModelo
    {
        [StringLength(InventarioModelosConstantes.LONG_NOMBRE_MAX)]
        [Required]
        public string Nombre { get; set; }

        [Range(InventarioModelosConstantes.CANTIDAD_MINIMA, InventarioModelosConstantes.CANTIDAD_MAXIMA)]
        public int Cantidad { get; set; }

        [StringLength(InventarioModelosConstantes.LONG_DESCR_MAX)]
        public string Descripcion { get; set; }

        [StringLength(InventarioModelosConstantes.LONG_NOTAS_MAX, MinimumLength = 10)]
        public string Notas { get; set; }

        public bool EstaEnVenta { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaVenta { get; set; }

        [Range(InventarioModelosConstantes.PRECIO_MINIMO, InventarioModelosConstantes.PRECIO_MAXIMO)]
        public decimal? PrecioCompra { get; set; }

        [Range(InventarioModelosConstantes.PRECIO_MINIMO, InventarioModelosConstantes.PRECIO_MAXIMO)]
        public decimal? PrecioFinalOActual { get; set; }

        public int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual List<Participante> Participantes { get; set; } = new List<Participante>();

        public virtual List<ArticuloGenero> ArticulosGeneros { get; set; } = new List<ArticuloGenero>();
    }
}