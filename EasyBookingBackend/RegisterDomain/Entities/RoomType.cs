using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterDomain.Entities
{
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Acronym { get; set; }
        [NotMapped]
        public ICollection<Room>? Rooms { get; set; }
        public RoomType() { }
    }
}
