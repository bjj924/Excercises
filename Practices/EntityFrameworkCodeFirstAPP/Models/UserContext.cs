using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirstAPP.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Users> Users { get; set; }
    }
}
