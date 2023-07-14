using RegisterDomain;
using RegisterDomain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterDataAccess.RoomType
{
    public interface IRoomTypeDAO
    {
        Task<List<RoomTypeDto>> GetAll();
        Task<RoomTypeDto> Get(Guid Id);
        Task<RoomTypeDto> Create(CreateOrUpdateRoomTypeDto roomType);
        Task<RoomTypeDto> Update(Guid id, CreateOrUpdateRoomTypeDto roomType);
        Task<RoomTypeDto> Delete(Guid Id);
    }
}
