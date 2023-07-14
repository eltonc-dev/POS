using System;

namespace RegisterDomain.Dtos
{
    public class CreateOrUpdateRoomDto
    {
        public int Flor { get; set; }
        public int Number { get; set; }
        public Guid RoomTypeId { get; set; }
    }
}
