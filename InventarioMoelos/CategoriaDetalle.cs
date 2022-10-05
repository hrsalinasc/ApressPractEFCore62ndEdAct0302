
using InventarioModelos.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioModelos
{
    public class CategoriaDetalle : IIdentificableModelo
    {
        [Key, ForeignKey("Categoria")]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(InventarioModelosConstantes.LONG_MAX_COLORVALOR)]
        public string ColorValor { get; set; }

        [Required]
        [StringLength(InventarioModelosConstantes.LONG_MAX_COLORNOMBRE)]
        public string ColorNombre { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
