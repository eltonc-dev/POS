using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDomain.Entities
{
    public class GuestEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string GivingName { get; set; }
        public string FamilyName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirhtDay { get; set; }
    }
}
