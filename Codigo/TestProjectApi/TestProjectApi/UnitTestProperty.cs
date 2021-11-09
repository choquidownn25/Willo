using CapaConexion.Models;
using CapaRepository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace TestProjectApi
{
    /// <summary>
    /// Para insertar
    /// </summary>
    public class UnitTestProperty
    {
        private PropertyRepository propertyRepository;
      

        [Fact]
        public void Post()
        {
            Property property = new Property
            {
                IdProperty = 1,
                Name = "Prueba",
                Address = "Cr2 # 72-42",
                Price=1,
                CodeInternal=1,
                IdOwnwe=1
            };
            propertyRepository = new PropertyRepository();
            Property propertyImage = property;
            var dato = propertyRepository.Add(propertyImage);
            if (dato != null)
            {
                Console.WriteLine("Dato Insertado");

            }
            else
                throw new ArgumentNullException(paramName: nameof(property), message: "Entidad no pueden ser null algunos de los campos");
        }

   
    }
}
