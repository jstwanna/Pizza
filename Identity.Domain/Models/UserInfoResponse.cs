using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class UserInfoResponse
    {
        public string? Username { get; set; } = string.Empty;
        public string? Role {  get; set; } = string.Empty;
    }
}
