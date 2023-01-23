using AutoMapper;
using TestBodega.Models;
using TestBodega.Models.Dto;

namespace TestBodega.BodegaMappers
{
    public class BodegaMapper : Profile
    {
        public BodegaMapper()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Producto, CrearProductoDto>().ReverseMap();

        }
    }
}
