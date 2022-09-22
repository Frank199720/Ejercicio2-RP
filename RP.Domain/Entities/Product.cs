using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
