using Microsoft.AspNetCore.Mvc;
using RegisterDataAccess.RoomType;
using RegisterDomain.Dtos;
using RegisterDomain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private IRoomTypeDAO _roomTypeDAO;
        public RoomTypesController(IRoomTypeDAO roomTypeDAO)
        {
            _roomTypeDAO = roomTypeDAO;
        }

        // GET: api/<RoomTypesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roomTypes = await _roomTypeDAO.GetAll();
                return Ok(roomTypes);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // GET api/<RoomTypesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var roomType = await _roomTypeDAO.Get(id);
                return Ok(roomType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RoomTypesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrUpdateRoomTypeDto roomType)
        {
            try
            {
                var roomTypeCreated = await _roomTypeDAO.Create(roomType);
                return Ok(roomTypeCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RoomTypesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateOrUpdateRoomTypeDto roomType)
        {
            try
            {
                var roomTypeCreated = await _roomTypeDAO.Update(id, roomType);
                return Ok(roomTypeCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RoomTypesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var roomTypeDeleted = await _roomTypeDAO.Delete(id);
                return Ok(roomTypeDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
