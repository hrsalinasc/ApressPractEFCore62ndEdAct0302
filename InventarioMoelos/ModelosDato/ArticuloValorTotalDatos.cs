﻿
namespace InventarioModelos.ModelosDato
{
    public class ArticuloValorTotalDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}
