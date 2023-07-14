using Microsoft.EntityFrameworkCore;
using RegisterDomain.Entities;

namespace RegisterDomain
{
    public class RegisterContext : DbContext
    {
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public RegisterContext(): base(GetOptions())
        {    
        }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "Data Source=TR-C7ZQ9S3;Initial Catalog=register;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(r => r.Rooms)
                .HasForeignKey(r => r.RoomTypeId);                
        }
    }
}
