
using System.ComponentModel.DataAnnotations;

namespace InventarioModelos
{
    public class Participante : AuditorModelo
    {
        [Required]
        [StringLength(InventarioModelosConstantes.LONG_MAX_PARTICIPANTENOMBRE)]
        public string Nombre { get; set; }

        [StringLength(InventarioModelosConstantes.LONG_MAX_PARTICIPANTEDESCR)]
        public string Descripcion { get; set; }

        public virtual List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
