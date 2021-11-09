using CapaConexion.Models;
using CapaRepository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationApi.Utilitis;
using Xunit;

namespace TestProjectApi
{
    public class UnitestGetAllOwner
    {
        private OwnerRepository OwnerRepository;
        private ImagesDAL images = new ImagesDAL();
        [Fact]
        public void Get()
        {
            try
            {
                OwnerRepository = new OwnerRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Owner> Items = OwnerRepository.GetAll();
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
