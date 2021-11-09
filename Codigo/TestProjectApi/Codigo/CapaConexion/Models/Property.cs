using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class Property
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int CodeInternal { get; set; }
        public int IdOwnwe { get; set; }
    }
}
