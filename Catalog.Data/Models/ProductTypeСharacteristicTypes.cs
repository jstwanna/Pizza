using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class ProductTypeСharacteristicTypes
    {
        public int Id { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int СharacteristicTypeId { get; set; }
        public СharacteristicType Сharacteristic { get; set; }
    }
}
