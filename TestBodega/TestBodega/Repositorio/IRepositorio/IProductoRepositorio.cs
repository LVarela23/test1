using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using TestBodega.Models;

namespace TestBodega.Repositorio.IRepositorio
{
    public interface IProductoRepositorio
    {
        ICollection<Producto> GetProductos();
        ICollection<Producto> GetProductosOptimos();
        ICollection<Producto> GetProductosDefectuosos();

        Producto GetProducto(int id);
        bool ExisteProducto(int id);
        bool ExisteCodigoProducto(int codigoProducto);
        bool CrearProducto(Producto producto);
        bool MarcarDefectuoso(Producto producto);
        bool MarcarOptimo(Producto producto);

        bool Guardar();

    }
}
