using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPromo.Entities
{
    public class Role
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        
    }
}
