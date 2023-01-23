using System;
using System.Collections.Generic;

#nullable disable

namespace TestBodega.Models
{
    public partial class MovimientoInventario
    {
        public int Id { get; set; }
        public int? IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int? TipoMovimiento { get; set; }
        public DateTime? FechaMovimiento { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual TiposDetalle TipoMovimientoNavigation { get; set; }
    }
}
