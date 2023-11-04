using RmDomain.Dtos;
using RMDomain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmBusinessRule.Services
{
    public interface IRevenueDayRule
    {
        public Task<List<GetRevenueByPeriodDto>> CreateRevenueByPeriod(CreateRevenueByPediodDto createDto);
        public Task<List<GetRevenueByPeriodDto>> GetRevenueByPeriod(GetRevenueByPeriodRequestDto dto);
    }
}
