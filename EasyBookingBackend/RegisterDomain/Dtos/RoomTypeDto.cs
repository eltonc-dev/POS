using System;

namespace RegisterDomain.Dtos
{
    public class RoomTypeDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Acronym { get; set; }
    }
}
