using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Database.Models
{
    public class ProductTypeСharacteristics
    {
        public int Id { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int СharacteristicId { get; set; }
        public Сharacteristic Сharacteristic { get; set; }
    }
}
