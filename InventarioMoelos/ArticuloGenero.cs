
using InventarioModelos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioModelos
{
    [Table("ArticulosGeneros")]
    [Index(nameof(ArticuloId), nameof(GeneroId), IsUnique = true)]
    public class ArticuloGenero : IIdentificableModelo
    {
        public int Id { get; set; }

        public virtual int ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }

        public virtual int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
