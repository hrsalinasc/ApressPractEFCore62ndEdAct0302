
namespace InventarioModelos.ModelosDato
{
    public class ArticuloDetalleDatos
    {
        public int Id { get; set; }
        public string ArticuloNombre { get; set; }
        public string ArticuloDescripcion { get; set; }
        public bool EstaActivo { get; set; }
        public bool	EstaEliminado { get; set; }
        public string Notas { get; set; }
        public decimal? PrecioFinalOActual { get; set; }
        public bool EstaEnVenta { get; set; }
        public DateTime? FechaCompra { get; set; }
        public decimal?	PrecioCompra { get; set; }
        public int?	Cantidad { get; set; }
        public DateTime? FechaVenta { get; set; }
        public string CategoriaNombre { get; set; }
        public bool? CategoriaEstaActivo { get; set; }
        public bool? CategoriaEstaEliminado { get; set; }
        public string CategoriaDetalleColorNombre { get; set; }
        public string CategoriaDetalleColorValor { get; set; }
        public string ParticipanteNombre { get; set; }
        public string ParticipanteDescripcion { get; set; }
        public bool? ParticipanteEstaActivo { get; set; }
        public bool? ParticipanteEstaEliminado { get; set; }
        public string GeneroNombre { get; set; }
        public bool? GeneroEstaActivo { get; set; }
        public bool? GeneroEstaEliminado { get; set; }
    }
}
