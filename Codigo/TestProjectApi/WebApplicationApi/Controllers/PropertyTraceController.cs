using CapaConexion.Models;
using CapaRepository.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApi.Controllers
{
    [Route("api/PropertyTrace")]
    [ApiController]
    [Consumes("application/json")]
    public class PropertyTraceController : ControllerBase
    {
        /// <summary>
        /// Trae la dll de la logica de negocio
        /// </summary
        private PropertyTraceRepository PropertyTraceRepository;

    

        // GET: api/<PropertyTraceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                PropertyTraceRepository = new PropertyTraceRepository();
                //Pasamos el listado de la conexión
                IEnumerable<PropertyTrace> Items = PropertyTraceRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        // GET api/<PropertyTraceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PropertyTraceRepository = new PropertyTraceRepository();
            var dato = PropertyTraceRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // POST api/<PropertyTraceController>
        [HttpPost]
        public IActionResult Post([FromBody] PropertyTrace payload)
        {
            PropertyTraceRepository = new PropertyTraceRepository();
            PropertyTrace propertyTrace = payload;
            var dato = PropertyTraceRepository.Add(propertyTrace);
            if (dato != null)
                return Ok(propertyTrace);
            else
                return BadRequest("Error : " + propertyTrace.ToString());
        }

        // PUT api/<PropertyTraceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PropertyTrace value)
        {
            PropertyTraceRepository = new PropertyTraceRepository();
            PropertyTrace propertyTrace = value;
            var dato = PropertyTraceRepository.Modify(propertyTrace);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // DELETE api/<PropertyTraceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Property value)
        {
            PropertyTraceRepository = new PropertyTraceRepository();
            Property property = value;
            var dato = PropertyTraceRepository.Delete(property.IdProperty);
            if (dato != null)
                return Ok(property);
            else
                return BadRequest("Error : " + property.ToString());
        }
    }
}
