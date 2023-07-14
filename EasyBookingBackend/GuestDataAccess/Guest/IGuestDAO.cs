using GuestDomain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataAccess.Guest
{
    public interface IGuestDAO
    {
        Task<List<GuestDto>> GetAll();
        Task<GuestDto> Get(Guid Id);
        Task<GuestDto> Create(CreateOrUpdateGuestDto guest);
        Task<GuestDto> Update(Guid id, CreateOrUpdateGuestDto guest);
        Task<GuestDto> Delete(Guid Id);
    }
}
