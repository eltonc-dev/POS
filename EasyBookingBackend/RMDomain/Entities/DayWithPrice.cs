using RMDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDomain.Entities
{
    public class DayWithPrice
    {
        public DateTime Day { get; set; }
        public List<PricePerRoomType> PriceList { get; set; }
    }
}
