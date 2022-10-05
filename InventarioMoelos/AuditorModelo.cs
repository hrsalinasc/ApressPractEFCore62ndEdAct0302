using InventarioModelos.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventarioModelos
{
    public abstract class AuditorModelo : IIdentificableModelo, IAuditableModelo, IActibableModelo, IEliminableLogico
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(InventarioModelosConstantes.LONG_USUARIOID_MAX)]
        public string CreadoPorUsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }

        [StringLength(InventarioModelosConstantes.LONG_USUARIOID_MAX)]
        public string ModificadoPorUsuarioId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool EstaActivo { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool EstaEliminado { get; set; }
    }
}
