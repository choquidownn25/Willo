using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class Personas
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdTipoDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
    }
}
