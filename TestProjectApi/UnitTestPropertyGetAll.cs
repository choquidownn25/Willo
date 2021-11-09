using CapaConexion.Models;
using CapaRepository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace TestProjectApi
{
    public class UnitTestPropertyGetAll
    {
        private PropertyRepository propertyRepository;
        [Fact]
        public void Get()
        {
            try
            {
                propertyRepository = new PropertyRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Property> Items = propertyRepository.GetAll();
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
