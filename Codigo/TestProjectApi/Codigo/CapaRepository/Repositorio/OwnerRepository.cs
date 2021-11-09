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
    public class OwnerRepository : IOwner
    {
        #region Atributos
        MichelPageContext sanaSoftwareContext = new MichelPageContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Owner Add(Owner entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Owner.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Owner Delete(int id)
        {
            if (id > 0)
            {
                Owner Owner = sanaSoftwareContext.Owner.Find(id);
                sanaSoftwareContext.Owner.Remove(Owner);
                sanaSoftwareContext.SaveChanges();
                return Owner;
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

        public IEnumerable<Owner> GetAll()
        {
            using (var context = new MichelPageContext())
            {
                var data = context.Owner.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Owner GetById(int id)
        {
            Owner brands = sanaSoftwareContext.Owner
                .Where(x => x.IdOwner == id)
                .FirstOrDefault();
            return brands;
        }

        public Owner Modify(Owner entity)
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
