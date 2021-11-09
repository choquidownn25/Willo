using CapaConexion.Models;
using CapaRepository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationApi.Utilitis;
using Xunit;

namespace TestProjectApi
{
    /// <summary>
    /// Para insertar
    /// </summary>
    public class UnitTestPropertyTrace
    {
        private PropertyTraceRepository PropertyTraceRepository;
        private ImagesDAL images = new ImagesDAL();

        [Fact]
        public void Post()
        {
            PropertyTrace property = new PropertyTrace
            {
                IdProperty=1,
                Value = 2,
                Tax = 1,
                DateSales = DateTime.Now
            };
            PropertyTraceRepository = new PropertyTraceRepository();
            PropertyTrace propertyImage = property;
            var dato = PropertyTraceRepository.Add(propertyImage);
            if (dato != null)
            {
               
                Console.WriteLine("Dato Insertado");

            }
            else
                throw new ArgumentNullException(paramName: nameof(property), message: "Entidad no pueden ser null algunos de los campos");
        }

       
    }
}
