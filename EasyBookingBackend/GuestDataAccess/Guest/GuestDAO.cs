using AutoMapper;
using GuestDomain.Dtos;
using GuestDomain.Entities;
using Microsoft.EntityFrameworkCore;
using RegisterDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataAccess.Guest
{
    public class GuestDAO: IGuestDAO
    {
        private GuestContext _dbContext;
        private readonly IMapper _mapper;

        public GuestDAO(GuestContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GuestDto>> GetAll()
        {
            var guests = await _dbContext.Guests.ToListAsync();
            return _mapper.Map<List<GuestDto>>(guests);
        }
        private async Task<GuestEntity> GetEntity(Guid Id)
        {
            var guest = await _dbContext.Guests.Where(r => r.Id == Id).FirstOrDefaultAsync();
            if (guest != null)
            {
                return guest;
            }
            throw new Exception("Guest Not Found");
        }
        public async Task<GuestDto> Get(Guid Id)
        {
            return _mapper.Map<GuestDto>(await GetEntity(Id));
        }

        public async Task<GuestDto> Delete(Guid Id)
        {
            var guest = await GetEntity(Id);
            _dbContext.Guests.Remove(guest);
            var rowAffected = await _dbContext.SaveChangesAsync();
            if (rowAffected > 0)
            {
                return _mapper.Map<GuestDto>(guest); ;
            }
            throw new Exception("Guest Deletion failed");
        }

        public async Task<GuestDto> Create(CreateOrUpdateGuestDto guestDto)
        {
            var guest = new GuestEntity();
            guest.GivingName = (string)guestDto.GivingName;
            guest.FamilyName = (string)guestDto.FamilyName;
            guest.BirhtDay = guestDto.BirhtDay;
            guest.Email = guestDto.Email;
            guest.DocumentNumber = guestDto.DocumentNumber;
            _dbContext.Guests.Add(guest);
            var rowsAffected = await _dbContext.SaveChangesAsync();
            if (rowsAffected > 0)
            {
                return _mapper.Map<GuestDto>(guest);
            }
            throw new Exception("Guest Save fail");
        }

        public async Task<GuestDto> Update(Guid id, CreateOrUpdateGuestDto guestDto)
        {
            var existingRoomType = await GetEntity(id);
            if (existingRoomType != null)
            {
                existingRoomType.GivingName = (string)guestDto.GivingName;
                existingRoomType.FamilyName = (string)guestDto.FamilyName;
                existingRoomType.BirhtDay = guestDto.BirhtDay;
                existingRoomType.Email = guestDto.Email;
                existingRoomType.DocumentNumber = guestDto.DocumentNumber;
                _dbContext.Guests.Update(existingRoomType);

                var rowsAffected = await _dbContext.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return _mapper.Map<GuestDto>(existingRoomType); ;
                }
            }
            else
            {
                throw new Exception("Guest Not Found");
            }

            throw new Exception("Guest Update fail");
        }
    }
}
