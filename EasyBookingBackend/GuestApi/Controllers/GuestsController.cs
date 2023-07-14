using Microsoft.AspNetCore.Mvc;
using GuestDataAccess.Guest;
using GuestDomain.Dtos;

namespace GuestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {

        private IGuestDAO _guestDAO;
        public GuestsController(IGuestDAO guestDAO)
        {
            _guestDAO = guestDAO;
        }

        // GET: api/<GuestController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var guests = await _guestDAO.GetAll();
                return Ok(guests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var room = await _guestDAO.Get(id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GuestController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrUpdateGuestDto createGuest)
        {
            try
            {
                var guestCreated = await _guestDAO.Create(createGuest);
                return Ok(guestCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GuestController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateOrUpdateGuestDto updateGuest)
        {
            try
            {
                var guestCreated = await _guestDAO.Update(id, updateGuest);
                return Ok(guestCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var guestDeleted = await _guestDAO.Delete(id);
                return Ok(guestDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
