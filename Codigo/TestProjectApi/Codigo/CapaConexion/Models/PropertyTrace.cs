using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class PropertyTrace
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSales { get; set; }
        public int Value { get; set; }
        public int Tax { get; set; }
        public int IdProperty { get; set; }
    }
}
