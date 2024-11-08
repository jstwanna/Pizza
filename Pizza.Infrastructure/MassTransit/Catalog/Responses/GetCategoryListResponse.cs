using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Infrastructure.MassTransit.Catalog.Responses
{
    public class GetCategoryListResponse
    {
        public string[] Categories { get; set; }
    }
}
