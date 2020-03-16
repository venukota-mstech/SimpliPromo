using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPromo.Models
{
    public class Register
    {
        [Key]
        public Guid RegisterId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
