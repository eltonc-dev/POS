using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMDomain.Entities;

namespace RMDomain.Dtos
{
    public class CreateRevenueByPediodDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PricePerRoomType> priceList { get; set; }
    }
}
