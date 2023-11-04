using RmDomain.Dtos;
using RMDomain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmBusinessRule.Services
{
    public class IRevenueDayRule
    {
        public Task<List<GetRevenueByPeriodDto>> CreateRevenueByPeriod(CreateRevenueByPediodDto createDto)
        {
            if(createDto.StartDate >= createDto.EndDate)
            {
                // Data final precisa ser maior do que a inicial
            }

            var initialDate = createDto.StartDate;
            do
            {

            } while (initialDate < createDto.EndDate);

            return null;
        }
        public Task<List<GetRevenueByPeriodDto>> GetRevenueByPeriod(GetRevenueByPeriodRequestDto dto)
        {
            return null;
        }
    }
}
