using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioModelos.ModelosDato
{
    public class ArticuloDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }

        public override string ToString()
        {
            return $"{Nombre, -25} | {Descripcion}";
        }
    }
}
