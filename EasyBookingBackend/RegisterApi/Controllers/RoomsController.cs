using Microsoft.AspNetCore.Mvc;
using RegisterDataAccess.Room;
using RegisterDomain.Dtos;
using RegisterDomain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomDAO _roomDAO;
        public RoomsController(IRoomDAO roomDAO)
        {
            _roomDAO = roomDAO;
        }

        // GET: api/<RoomsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rooms = await _roomDAO.GetAll();
                return Ok(rooms);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var room = await _roomDAO.Get(id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RoomsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrUpdateRoomDto room)
        {
            try
            {
                var roomCreated = await _roomDAO.Create(room);
                return Ok(roomCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateOrUpdateRoomDto room)
        {
            try
            {
                var roomCreated = await _roomDAO.Update(id, room);
                return Ok(roomCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var roomDeleted = await _roomDAO.Delete(id);
                return Ok(roomDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
