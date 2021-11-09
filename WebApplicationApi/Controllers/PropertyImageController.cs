using CapaConexion.Models;
using CapaRepository.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationApi.Utilitis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApi.Controllers
{
    [Route("api/PropertyImage")]
    [ApiController]
    [Consumes("application/json")]
    public class PropertyImageController : ControllerBase
    {
        /// <summary>
        /// Trae la dll de la logica de negocio
        /// </summary
        private PropertyImageRepository PropertyImageRepository;
        private ImagesDAL images = new ImagesDAL();//Agrega la imagen
        
        // GET: api/<PropertyImageController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                PropertyImageRepository = new PropertyImageRepository();
                //Pasamos el listado de la conexión
                IEnumerable<PropertyImage> Items = PropertyImageRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        // GET api/<PropertyImageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PropertyImageRepository = new PropertyImageRepository();
            var dato = PropertyImageRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // POST api/<PropertyImageController>
        [HttpPost]
        public IActionResult Post([FromBody] PropertyImage payload)
        {
            PropertyImageRepository = new PropertyImageRepository();
            PropertyImage propertyImage = payload;
            var dato = PropertyImageRepository.Add(propertyImage);
            if (dato != null) 
            {
                string datoImagen = "Imagen";
                images.SaveImage(payload.File, datoImagen);
                return Ok(propertyImage);
            }
            else
                return BadRequest("Error : " + propertyImage.ToString());
        }

        // PUT api/<PropertyImageController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PropertyImage value)
        {
            PropertyImageRepository = new PropertyImageRepository();
            PropertyImage propertyImage = value;
            var dato = PropertyImageRepository.Modify(propertyImage);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // DELETE api/<PropertyImageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(PropertyImage value)
        {
            PropertyImageRepository = new PropertyImageRepository();
            PropertyImage propertyImage = value;
            var dato = PropertyImageRepository.Delete(propertyImage.IdProperty);
            if (dato != null)
                return Ok(propertyImage);
            else
                return BadRequest("Error : " + propertyImage.ToString());
        }
    }
}
