using GuestDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RegisterDomain
{
    public class GuestContext : DbContext
    {
        public DbSet<GuestEntity> Guests { get; set; }

        public GuestContext(): base(GetOptions())
        {    
        }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "Data Source=TR-C7ZQ9S3;Initial Catalog=guest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                             
        }
    }
}
