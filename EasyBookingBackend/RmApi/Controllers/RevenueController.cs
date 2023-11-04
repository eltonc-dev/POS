using Microsoft.AspNetCore.Mvc;
using RMDomain.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        // POST: api/<RevenueController>/getByPeriod
        [HttpPost("getByPeriod")]
        public IEnumerable<string> GetRevenueByPeriod([FromBody] GetRevenueByPediodDto getRevenueDto )
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<RevenueController>
        [HttpPost]
        public string CreateRevenue([FromBody] CreateRevenueByPediodDto createRevenueDto)
        {
            return "value";
        }
    }
}
