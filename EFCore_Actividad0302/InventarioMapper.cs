using AutoMapper;
using InventarioModelos;
using InventarioModelos.ModelosDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Actividad0302
{
    public class InventarioMapper : Profile
    {
        public InventarioMapper()
        {
            CrearMapeos();
        }

        private void CrearMapeos()
        {
            CreateMap<Articulo, ArticuloDatos>();
            CreateMap<Categoria, CategoriaDatos>();
        }
    }
}
