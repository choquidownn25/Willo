using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class Owner
    {
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
