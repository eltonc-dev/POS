using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDomain.Entities
{
    public class RevenueDay
    {
        public DateTime Day { get; set; }
        public List<PricePerRoomType> priceList { get; set; }

    }
}
