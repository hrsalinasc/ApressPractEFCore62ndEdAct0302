namespace InventarioModelos.Interfaces
{
    public interface IAuditableModelo
    {
        public string CreadoPorUsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPorUsuarioId { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
