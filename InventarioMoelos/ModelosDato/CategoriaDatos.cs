using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioModelos.ModelosDato
{
    public class CategoriaDatos
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public CategoriaDetalleDatos CategoriaDetalle { get; set; }
    }
}
