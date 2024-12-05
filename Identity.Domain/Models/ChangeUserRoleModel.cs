using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class ChangeUserRoleModel
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
        public string OldRole { get; set; }
    }
}
