
using System.ComponentModel.DataAnnotations;

namespace InventarioModelos
{
    public class Genero : AuditorModelo
    {
        [Required]
        [StringLength(InventarioModelosConstantes.LONG_NOMBRE_MAX)]
        public string Nombre { get; set; }

        public virtual List<ArticuloGenero> ArticulosGeneros { get; set; } = new List<ArticuloGenero>();
    }
}
