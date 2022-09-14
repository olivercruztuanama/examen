using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba.Entitys;
using Prueba.Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly ILogger<InventarioController> _logger;
        private readonly IProductosServicios _productosServicios;

        public InventarioController(ILogger<InventarioController> logger, IProductosServicios productosServicios)
        {
            _logger = logger;
            _productosServicios = productosServicios;
        }

        // GET: api/<InventarioController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Get()
        {
            var response = new ResponseDTO();
            try
            {
                response.ObjModel = await _productosServicios.GetListaInventario();
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

        // GET api/<InventarioController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO))]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO();
            try
            {
                response.ObjModel = await _productosServicios.GetInventarioById(id);
                response.Description = "Transaction Sucessfully";
                response.Status = (int)HttpStatusCode.OK;
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

        // POST api/<InventarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InventarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InventarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}