using CapaConexion.Models;
using CapaRepository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationApi.Utilitis;
using Xunit;

namespace TestProjectApi
{
    public class UnitTestImageGetAll
    {
        private PropertyImageRepository PropertyImageRepository;
        [Fact]
        public void Get()
        {
            try
            {
                PropertyImageRepository = new PropertyImageRepository();
                //Pasamos el listado de la conexión
                IEnumerable<PropertyImage> Items = PropertyImageRepository.GetAll();
                int Count = Items.Count();
                Console.WriteLine("" + new { Items, Count });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message.ToString());
            }
        }
    }
}
