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
            CreateMap<Categoria, CategoriaDatos>()
                    .ForMember(x => x.Categoria, opt => opt.MapFrom(y => y.Nombre))
                    .ReverseMap()
                    .ForMember(y => y.Nombre, opt => opt.MapFrom(x => x.Categoria));
            CreateMap<CategoriaDetalle, CategoriaDetalleDatos>()
                    .ForMember(x => x.Color, opt => opt.MapFrom(y => y.ColorNombre))
                    .ForMember(x => x.Valor, opt => opt.MapFrom(y => y.ColorValor))
                    .ReverseMap()
                    .ForMember(y => y.ColorValor, opt => opt.MapFrom(x => x.Valor))
                    .ForMember(y => y.ColorNombre, opt => opt.MapFrom(x => x.Color));
        }
    }
}
