using CapaConexion.Models;
using CapaService.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace CapaRepository.Repositorio
{
    public class PropertyImageRepository : IPropertyImage
    {

        #region Atributos
        MichelPageContext sanaSoftwareContext = new MichelPageContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public PropertyImage Add(PropertyImage entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.PropertyImage.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public PropertyImage Delete(int id)
        {
            if (id > 0)
            {
                PropertyImage PropertyImage = sanaSoftwareContext.PropertyImage.Find(id);
                sanaSoftwareContext.PropertyImage.Remove(PropertyImage);
                sanaSoftwareContext.SaveChanges();
                return PropertyImage;
            }
            else
                throw new ArgumentException("Debe ingresar un numero valido");


        }

        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public IEnumerable<PropertyImage> GetAll()
        {
            using (var context = new MichelPageContext())
            {
                var data = context.PropertyImage.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public PropertyImage GetById(int id)
        {
            PropertyImage brands = sanaSoftwareContext.PropertyImage
                .Where(x => x.IdPropertyImage == id)
                .FirstOrDefault();
            return brands;
        }

        public PropertyImage Modify(PropertyImage entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Entry(entity).State = EntityState.Modified;
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }
    }
}
