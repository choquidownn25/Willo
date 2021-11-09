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
    [Route("api/Owner")]
    [ApiController]
    [Consumes("application/json")]
    public class OwnerController : ControllerBase
    {

       /// <summary>
       /// Trae la dll de la logica de negocio
       /// </summary>
        private  OwnerRepository StoresRepository;

     
        // GET: api/<OwnerController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                StoresRepository = new OwnerRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Owner> Items = StoresRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            StoresRepository = new OwnerRepository();
            var dato = StoresRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // POST api/<OwnerController>
        [HttpPost]
        public IActionResult Post( Owner payload)
        {
            StoresRepository = new OwnerRepository();
            Owner Stores = payload;
            var dato = StoresRepository.Add(Stores);
            if (dato != null)
                return Ok(Stores);
            else
                return BadRequest("Error : " + Stores.ToString());
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Owner value)
        {
            StoresRepository = new OwnerRepository();
            Owner Stores = value;
            var dato = StoresRepository.Modify(Stores);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Owner value)
        {
            StoresRepository = new OwnerRepository();
            Owner Stores = value;
            var dato = StoresRepository.Delete(Stores.IdOwner);
            if (dato != null)
                return Ok(Stores);
            else
                return BadRequest("Error : " + Stores.ToString());
        }
    
    }
}
