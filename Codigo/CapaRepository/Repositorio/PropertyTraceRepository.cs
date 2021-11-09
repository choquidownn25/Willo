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
    public class PropertyTraceRepository : IPropertyTrace
    {
        #region Atributos
        MichelPageContext sanaSoftwareContext = new MichelPageContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public PropertyTrace Add(PropertyTrace entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.PropertyTrace.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public PropertyTrace Delete(int id)
        {
            if (id > 0)
            {
                PropertyTrace PropertyTrace = sanaSoftwareContext.PropertyTrace.Find(id);
                sanaSoftwareContext.PropertyTrace.Remove(PropertyTrace);
                sanaSoftwareContext.SaveChanges();
                return PropertyTrace;
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

        public IEnumerable<PropertyTrace> GetAll()
        {
            using (var context = new MichelPageContext())
            {
                var data = context.PropertyTrace.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public PropertyTrace GetById(int id)
        {
            PropertyTrace brands = sanaSoftwareContext.PropertyTrace
                .Where(x => x.IdPropertyTrace == id)
                .FirstOrDefault();
            return brands;
        }

        public PropertyTrace Modify(PropertyTrace entity)
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
