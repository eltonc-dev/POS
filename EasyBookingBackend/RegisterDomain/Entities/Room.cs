using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterDomain.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Flor { get; set; }
        public int Number { get; set; }
        public  Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }


    }
}
