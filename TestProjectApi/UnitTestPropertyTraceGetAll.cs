using CapaConexion.Models;
using CapaRepository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationApi.Utilitis;
using Xunit;
namespace TestProjectApi
{
    public class UnitTestPropertyTraceGetAll
    {
        private PropertyTraceRepository PropertyTraceRepository;
        [Fact]
        public void Get()
        {
            try
            {
                PropertyTraceRepository = new PropertyTraceRepository();
                //Pasamos el listado de la conexión
                IEnumerable<PropertyTrace> Items = PropertyTraceRepository.GetAll();
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
