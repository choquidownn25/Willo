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
    public class PropertyRepository : IProperty
    {
        #region Atributos
        MichelPageContext sanaSoftwareContext = new MichelPageContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion
        public Property Add(Property entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Property.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Property Delete(int id)
        {
            if (id > 0)
            {
                Property Property = sanaSoftwareContext.Property.Find(id);
                sanaSoftwareContext.Property.Remove(Property);
                sanaSoftwareContext.SaveChanges();
                return Property;
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

        public IEnumerable<Property> GetAll()
        {
            using (var context = new MichelPageContext())
            {
                var data = context.Property.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Property GetById(int id)
        {
            Property brands = sanaSoftwareContext.Property
                .Where(x => x.IdProperty == id)
                .FirstOrDefault();
            return brands;
        }

        public Property Modify(Property entity)
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
