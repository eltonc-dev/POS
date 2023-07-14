using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegisterDomain;
using RegisterDomain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterDataAccess.RoomType
{
    public class RoomTypeDAO : IRoomTypeDAO
    {
        private RegisterContext _dbContext;
        private readonly IMapper _mapper;

        public RoomTypeDAO(RegisterContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<RoomTypeDto>> GetAll()
        {
            var roomTypes = await _dbContext.RoomTypes.ToListAsync();
            return _mapper.Map<List<RoomTypeDto>>(roomTypes);
        }
        private async Task<RegisterDomain.Entities.RoomType> GetEntity(Guid Id)
        {
            var roomType = await _dbContext.RoomTypes.Where(r => r.Id == Id).FirstOrDefaultAsync();
            if (roomType != null)
            {
                return roomType;
            }
            throw new Exception("Room Type Not Found");
        }
        public async Task<RoomTypeDto> Get(Guid Id)
        {
           return _mapper.Map<RoomTypeDto>(await GetEntity(Id));
        }

        public async Task<RoomTypeDto> Delete(Guid Id)
        {
            var roomType = await GetEntity(Id);
            _dbContext.RoomTypes.Remove(roomType);
            var rowAffected = await _dbContext.SaveChangesAsync();
            if(rowAffected > 0)
            {
                return _mapper.Map<RoomTypeDto>(roomType); ;
            }
            throw new Exception("Room Type deletion failed");
        }

        public async Task<RoomTypeDto> Create(CreateOrUpdateRoomTypeDto roomTypeDto)
        {
            var roomType = new RegisterDomain.Entities.RoomType();
            roomType.Name = (string)roomTypeDto.Name;
            roomType.Description = (string)roomTypeDto.Description;
            roomType.Acronym = roomTypeDto.Acronym;
            _dbContext.RoomTypes.Add(roomType);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            if (rowsAffected > 0)
            {
                return _mapper.Map<RoomTypeDto>(roomType);
            }
            throw new Exception("Room Type Save fail");
        }

        public async Task<RoomTypeDto> Update(Guid id, CreateOrUpdateRoomTypeDto roomTypeDto)
        {
            var existingRoomType = await GetEntity(id);
            if(existingRoomType != null)
            {
                existingRoomType.Name = roomTypeDto.Name;
                existingRoomType.Acronym = roomTypeDto.Acronym;
                existingRoomType.Description = roomTypeDto.Description;
                _dbContext.RoomTypes.Update(existingRoomType);

                var rowsAffected = await _dbContext.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return _mapper.Map<RoomTypeDto>(existingRoomType); ;
                }
            } else
            {
                throw new Exception("Room Type Not Found");
            }

            throw new Exception("Room Type Update fail");
        }
    }
}
