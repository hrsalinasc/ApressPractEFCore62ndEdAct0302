
using System.ComponentModel.DataAnnotations;

namespace InventarioModelos
{
    public class Categoria : AuditorModelo
    {
        [StringLength(InventarioModelosConstantes.LONG_NOMBRE_MAX)]
        public string Nombre { get; set; }

        public virtual List<Articulo> Articulos { get; set; } = new List<Articulo>();

        public virtual CategoriaDetalle CategoriaDetalle { get; set; }
    }
}
