using System;

namespace TestBodega.Models.Dto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public int? CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public int? Stock { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
