using System;
using System.Collections.Generic;

#nullable disable

namespace TestBodega.Models
{
    public partial class Producto
    {
        public Producto()
        {
            MovimientoInventarios = new HashSet<MovimientoInventario>();
        }

        public int Id { get; set; }
        public int? CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public int? Stock { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
