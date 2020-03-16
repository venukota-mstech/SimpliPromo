using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpliPromo.Entities
{
    public class Person
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public List<Address> Addresses { get; set; }
        [NotMapped]
        public List<PersonRole> PersonRoles { get; set; }
    }
}
