using RegisterDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterDomain.Dtos
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int Flor { get; set; }
        public int Number { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}
