using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba.Entitys;
using Prueba.Logica.Interfaces;
using Prueba.ORM.Effitec;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //private readonly ILogger<ProductoController> _logger;
        private readonly IProductosServicios _productosServicios;
        private readonly ILogger _logger;

        public ProductoController(ILogger<ProductoController> logger, IProductosServicios productosServicios)
        {
            _logger = logger;
            _productosServicios = productosServicios;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Get()
        {
            var response = new ResponseDTO();
            try
            {
                response.ObjModel = _productosServicios.GetListaProducto();
                response.Description = "Transaction Sucessfully";
                response.Status = (int)HttpStatusCode.OK;
                _logger.LogInformation("HttpGet: " + response.Description);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Description = "Error al consultar: " + ex.Message
                };
                _logger.LogError(ex.Message);
            }

            return Ok(response);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO();
            try
            {
                response.ObjModel = _productosServicios.GetProductoById(id);
                response.Description = "Transaction Sucessfully";
                _logger.LogInformation("HttpGet/id: " + response.Description);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Description = "Error al consultar: " + ex.Message
                };
                _logger.LogError(ex.Message);
            }

            return Ok(response);
        }

        // POST api/<ProductoController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Post([FromBody] ProductoRequest obj)
        {
            var response = new ResponseDTO();
            try
            {
                _productosServicios.AgregarProducto(obj);
                response.ObjModel = obj;
                response.Description = "Transaction Sucessfully";
                response.Status = (int)HttpStatusCode.OK;
                _logger.LogInformation("HttpPost: " + response.Description);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Description = "Error al insertar: " + ex.Message
                };
                _logger.LogError(ex.Message);
            }

            return Ok(response);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Put(int id, [FromBody] Producto obj)
        {
            var response = new ResponseDTO();
            try
            {
                obj.Id = id;
                _productosServicios.ModificarProducto(obj);
                response.ObjModel = obj;
                response.Description = "Transaction Sucessfully";
                response.Status = (int)HttpStatusCode.OK;
                _logger.LogInformation("HttpPut: " + response.Description);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Description = "Error al modificar: " + ex.Message
                };
                _logger.LogError(ex.Message);
            }

            return Ok(response);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO();
            try
            {
                _productosServicios.EliminarProducto(id);
                response.Description = "Transaction Sucessfully";
                response.Status = (int)HttpStatusCode.OK;
                _logger.LogInformation("HttpDelete: " + response.Description);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Description = "Error al eliminar: " + ex.Message
                };
                _logger.LogError(ex.Message);
            }

            return Ok(response);
        }
    }
}