using AutoMapper;
using RegisterDomain.Dtos;
using RegisterDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegisterDataAccess.Room
{
    public class RoomDAO: IRoomDAO
    {
        private RegisterContext _dbContext;
        private readonly IMapper _mapper;

        public RoomDAO(RegisterContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> GetAll()
        {
            var rooms = await _dbContext.Rooms.ToListAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }
        private async Task<RegisterDomain.Entities.Room> GetEntity(Guid Id)
        {
            var room = await _dbContext.Rooms.Where(r => r.Id == Id).FirstOrDefaultAsync();
            if (room != null)
            {
                return room;
            }
            throw new Exception("Room Not Found");
        }
        public async Task<RoomDto> Get(Guid Id)
        {
            return _mapper.Map<RoomDto>(await GetEntity(Id));
        }

        public async Task<RoomDto> Delete(Guid Id)
        {
            var room = await GetEntity(Id);
            _dbContext.Rooms.Remove(room);
            var rowAffected = await _dbContext.SaveChangesAsync();
            if (rowAffected > 0)
            {
                return _mapper.Map<RoomDto>(room); ;
            }
            throw new Exception("Room deletion failed");
        }

        public async Task<RoomDto> Create(CreateOrUpdateRoomDto createRoom)
        {
            var room = new RegisterDomain.Entities.Room();
            room.Flor = (int)createRoom.Flor;
            room.Number = (int)createRoom.Number;
            room.RoomTypeId = createRoom.RoomTypeId;
            _dbContext.Rooms.Add(room);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            if (rowsAffected > 0)
            {
                return _mapper.Map<RoomDto>(room);
            }
            throw new Exception("Room Save fail");
        }

        public async Task<RoomDto> Update(Guid id, CreateOrUpdateRoomDto roomDto)
        {
            var existingRoom = await GetEntity(id);
            if (existingRoom != null)
            {
                existingRoom.Number = roomDto.Number;
                existingRoom.Flor = roomDto.Flor;
                existingRoom.RoomTypeId = roomDto.RoomTypeId;
                _dbContext.Rooms.Update(existingRoom);

                var rowsAffected = await _dbContext.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return _mapper.Map<RoomDto>(existingRoom); ;
                }
            }
            else
            {
                throw new Exception("Room Not Found");
            }

            throw new Exception("Room Update fail");
        }
    }
}
