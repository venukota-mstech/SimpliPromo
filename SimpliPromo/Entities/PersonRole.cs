using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPromo.Entities
{
    public class PersonRole
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int PersonRoleId { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
    }
}
