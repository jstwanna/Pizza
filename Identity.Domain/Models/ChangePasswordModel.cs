using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class ChangePasswordModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
