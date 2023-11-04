using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDomain.Entities
{
    public class PricePerRoomType
    {
        public Guid RoomTypeId { get; set; }
        public double Price { get; set; }
    }
}
