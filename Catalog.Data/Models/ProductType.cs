using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<СharacteristicType> Сharacteristics { get; set; } = new();
    }
}
