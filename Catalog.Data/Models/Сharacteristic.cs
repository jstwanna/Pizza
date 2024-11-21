using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Models
{
    public class Сharacteristic
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int CharacteristicTypeId { get; set; }
        public СharacteristicType CharacteristicType { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
