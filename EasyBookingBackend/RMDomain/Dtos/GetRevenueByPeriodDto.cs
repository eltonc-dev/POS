using RmDomain.Entities;
using RMDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDomain.Dtos
{
    public class GetRevenueByPeriodDto
    {
        public List<DayWithPrice> Days { get; set; }
    }
}
