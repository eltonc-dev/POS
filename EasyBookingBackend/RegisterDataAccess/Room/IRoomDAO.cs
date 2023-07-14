using RegisterDomain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterDataAccess.Room
{
    public interface IRoomDAO
    {
        Task<List<RoomDto>> GetAll();
        Task<RoomDto> Get(Guid Id);
        Task<RoomDto> Create(CreateOrUpdateRoomDto room);
        Task<RoomDto> Update(Guid id, CreateOrUpdateRoomDto room);
        Task<RoomDto> Delete(Guid Id);
    }
}
