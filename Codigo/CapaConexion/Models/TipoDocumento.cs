using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Personas = new HashSet<Personas>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Personas> Personas { get; set; }
    }
}
