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
    [Route("api/Property")]
    [ApiController]
    [Consumes("application/json")]
    public class PropertyController : ControllerBase
    {
        /// <summary>
        /// Trae la dll de la logica de negocio
        /// </summary
        private PropertyRepository propertyRepository;

     

        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                propertyRepository = new PropertyRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Property> Items = propertyRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            propertyRepository = new PropertyRepository();
            var dato = propertyRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // POST api/<PropertyController>
        [HttpPost]
        public IActionResult Post(Property payload)
        {
            propertyRepository = new PropertyRepository();
            Property property = payload;
            var dato = propertyRepository.Add(property);
            if (dato != null)
                return Ok(property);
            else
                return BadRequest("Error : " + property.ToString());
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,  Property value)
        {
            propertyRepository = new PropertyRepository();
            Property property = value;
            var dato = propertyRepository.Modify(property);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Property value)
        {
            propertyRepository = new PropertyRepository();
            Property property = value;
            var dato = propertyRepository.Delete(property.IdProperty);
            if (dato != null)
                return Ok(property);
            else
                return BadRequest("Error : " + property.ToString());
        }
    }
}
