using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDomain.Dtos
{
    public class CreateOrUpdateGuestDto
    {
        public string GivingName { get; set; }
        public string FamilyName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirhtDay { get; set; }
    }
}
