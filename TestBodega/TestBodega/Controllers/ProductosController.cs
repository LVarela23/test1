using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestBodega.Models;
using TestBodega.Models.Dto;
using TestBodega.Repositorio.IRepositorio;

namespace TestBodega.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepositorio _ProdRepo;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepositorio ProdRepo, IMapper mapper)
        {
            _ProdRepo = ProdRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Productos")]
        public IActionResult GetProductos()
        {
            try
            {
                var ListProductos = _ProdRepo.GetProductos();

                var ListProductosDto = new List<ProductoDto>();

                foreach (var oProducto in ListProductos)
                {
                    ListProductosDto.Add(_mapper.Map<ProductoDto>(oProducto));
                }

                return Ok(ListProductosDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("ProductosDefectuosos")]
        public IActionResult GetProductosDefectuosos()
        {
            try
            {
                var ListProductos = _ProdRepo.GetProductosDefectuosos();

                var ListProductosDto = new List<ProductoDto>();

                foreach (var oProducto in ListProductos)
                {
                    ListProductosDto.Add(_mapper.Map<ProductoDto>(oProducto));
                }

                return Ok(ListProductosDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("ProductosOptimos")]
        public IActionResult GetProductosOptimos()
        {
            try
            {
                var ListProductos = _ProdRepo.GetProductosOptimos();

                var ListProductosDto = new List<ProductoDto>();

                foreach (var oProducto in ListProductos)
                {
                    ListProductosDto.Add(_mapper.Map<ProductoDto>(oProducto));
                }

                return Ok(ListProductosDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("GuardarProducto")]
        public IActionResult GuardarProducto([FromBody] CrearProductoDto crearProductoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var oProducto = _mapper.Map<Producto>(crearProductoDto);
            var producto = _ProdRepo.CrearProducto(oProducto);

            if (producto)
            {
                return CreatedAtRoute("Productos",producto);
            }
            return StatusCode(500, "Algo salio mal");

        }
        [HttpPatch]
        [Route("MarcarProductoOptimo")]
        public IActionResult MarcarProductoOptimo([FromBody] ProductoDto productoDto)
        {
            try
            {
               
                if (productoDto == null)
                {
                     return BadRequest(ModelState);
                }
                var producto = _mapper.Map<Producto>(productoDto);
                if (!_ProdRepo.MarcarOptimo(producto))
                {
                    ModelState.AddModelError("", $"Algo salió mal actualizando el producto con codigo: {producto.CodigoProducto}");
                    return StatusCode(404, ModelState);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch]
        [Route("MarcarProductoDefectuoso")]
        public IActionResult MarcarProductoDefectuoso([FromBody] ProductoDto productoDto)
        {
            try
            {
                if (productoDto == null)
                {
                    return BadRequest(ModelState);
                }
                var producto = _mapper.Map<Producto>(productoDto);
                if (!_ProdRepo.MarcarDefectuoso(producto))
                {
                    ModelState.AddModelError("", $"Algo salió mal actualizando el producto con codigo: {producto.CodigoProducto}");
                    return StatusCode(404, ModelState);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
